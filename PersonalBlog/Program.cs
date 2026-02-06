using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using PersonalBlog;
using PersonalBlog.Interfaces;
using PersonalBlog.Strategies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IAmazonDynamoDB>(_ =>
    new AmazonDynamoDBClient(
        "fake",
        "fake",
        new AmazonDynamoDBConfig
        {
            ServiceURL = "http://localhost:8000"
        }
    )
);

builder.Services.AddSingleton<IDynamoDBContext>(sp =>
{
    var client = sp.GetRequiredService<IAmazonDynamoDB>();

    var contextConfig = new DynamoDBContextConfig
    {
        ConsistentRead = true
    };

    return new DynamoDBContext(client, contextConfig);
});

builder.Services.AddScoped<IDataService, DynamoDbDataService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IAuthorizer, IPBasedAuthorizer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    await DbExtensions.EnsureTableExistsAsync(app.Services);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
