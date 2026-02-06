using DIPractise;
using DIPractise.Buss;
using DIPractise.Data;
using DIPractise.UI;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();
// services.AddScoped<IDataAccess, MySQLDataAccess>();
// services.AddScoped<IBusiness, Business>();
// services.AddScoped<UserInterface>();

services.AddScoped<Scoped>();
services.AddTransient<Transient>();
services.AddSingleton<Singleton>();


ServiceProvider sp = services.BuildServiceProvider();

// UserInterface ui = sp.GetRequiredService<UserInterface>();

// ui.Signup();

Parallel.For(1, 5, i =>
{
    var scopedObject = sp.GetRequiredService<Scoped>();
    var transientObject = sp.GetRequiredService<Transient>();
    var singletonObject = sp.GetRequiredService<Singleton>();

    Console.WriteLine($"Singleton Object ID: {singletonObject.GetHashCode()}");
    Console.WriteLine($"Scoped Object ID: {scopedObject.GetHashCode()}");
    Console.WriteLine($"Transient Object ID: {transientObject.GetHashCode()}");
});