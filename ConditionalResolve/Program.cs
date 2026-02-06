using ConditionalResolve;
using ConditionalResolve.Enums;
using ConditionalResolve.Interfaces;
using ConditionalResolve.Services;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();

services.AddScoped<EUTaxCalculator>();
services.AddScoped<AUTaxCalculator>();

services.AddScoped<Func<Regions, ITaxCalculator>>(sp => key =>
{
    return key switch
    {
        Regions.Europe => sp.GetRequiredService<EUTaxCalculator>(),
        Regions.Australia => sp.GetRequiredService<AUTaxCalculator>(),
        _ => throw new NotImplementedException(),
    };
});

services.AddSingleton<Purchase>();

var purchase = services.BuildServiceProvider().GetRequiredService<Purchase>();
purchase.Checkout(Regions.Europe, 1000);