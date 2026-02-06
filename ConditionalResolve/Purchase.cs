using ConditionalResolve.Enums;
using ConditionalResolve.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ConditionalResolve;

public class Purchase(IServiceProvider provider)
{
    public void Checkout(Regions region, double total)
    {
        var taxCalculator = provider.GetRequiredKeyedService<ITaxCalculator>(region);
        var tax = total * taxCalculator.Calculate() / 100;
        var payment = Math.Round(total + tax, 2);
        Console.WriteLine($"Payment made: {payment} rupees");
    }
}
