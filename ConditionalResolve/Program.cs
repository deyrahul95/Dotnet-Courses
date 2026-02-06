using ConditionalResolve;
using ConditionalResolve.Enums;
using ConditionalResolve.Interfaces;
using ConditionalResolve.Services;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();

services.AddKeyedScoped<ITaxCalculator, EUTaxCalculator>(Regions.Europe);
services.AddKeyedScoped<ITaxCalculator, AUTaxCalculator>(Regions.Australia);

services.AddSingleton<Purchase>();

var purchase = services.BuildServiceProvider().GetRequiredService<Purchase>();
purchase.Checkout(Regions.Australia, 1000);
