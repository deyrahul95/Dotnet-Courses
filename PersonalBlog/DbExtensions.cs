using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using PersonalBlog.Models;

namespace PersonalBlog;

public static class DbExtensions
{
    public const string PostsTableName = "Posts";

    public static async Task EnsureTableExistsAsync(IServiceProvider services)
    {
        var client = services.GetRequiredService<IAmazonDynamoDB>();
        var context = services.GetRequiredService<IDynamoDBContext>();

        var tables = await client.ListTablesAsync();

        if (tables.TableNames.Contains(PostsTableName))
        {
            await SeedAsync(context);
            return;
        }

        await client.CreateTableAsync(new CreateTableRequest
        {
            TableName = "Posts",
            BillingMode = BillingMode.PAY_PER_REQUEST,
            AttributeDefinitions =
            [
                new("Id", ScalarAttributeType.S)
            ],
            KeySchema =
            [
                new("Id", KeyType.HASH)
            ]
        });

        await WaitForTableToBeActive(client);
        await SeedAsync(context);
    }

    private static async Task WaitForTableToBeActive(IAmazonDynamoDB client)
    {
        while (true)
        {
            var response = await client.DescribeTableAsync(PostsTableName);

            if (response.Table.TableStatus == TableStatus.ACTIVE)
                break;

            await Task.Delay(500);
        }
    }

    public static async Task SeedAsync(IDynamoDBContext context)
    {
        // Check if table already has data
        var existing = await context
            .ScanAsync<Post>([])
            .GetRemainingAsync();

        if (existing.Count != 0)
        {
            return;
        }

        var now = DateTime.UtcNow;

        var posts = new List<Post>
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Getting Started with .NET",
                Content = "An introduction to building applications using .NET and ASP.NET Core.",
                CreatedAt = now
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Understanding Dependency Injection",
                Content = "How DI works in ASP.NET Core and why it matters.",
                CreatedAt = now
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Working with DynamoDB Local",
                Content = "How to configure and use DynamoDB Local for development.",
                CreatedAt = now
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Clean Architecture in Practice",
                Content = "Applying Clean Architecture principles in modern .NET apps.",
                CreatedAt = now
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Async/Await Best Practices",
                Content = "Avoid common pitfalls when writing asynchronous code in C#.",
                CreatedAt = now
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "REST API Design Tips",
                Content = "Designing scalable and maintainable REST APIs.",
                CreatedAt = now
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Using Entity Framework Core",
                Content = "A practical guide to EF Core and data persistence.",
                CreatedAt = now
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Logging and Monitoring",
                Content = "Implementing structured logging and monitoring in .NET apps.",
                CreatedAt = now
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Dickering ASP.NET Applications",
                Content = "Containerizing your .NET application using Docker.",
                CreatedAt = now
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Deploying to AWS",
                Content = "Steps to deploy your ASP.NET Core application to AWS.",
                CreatedAt = now
            }
        };

        foreach (var post in posts)
        {
            await context.SaveAsync(post);
        }
    }
}
