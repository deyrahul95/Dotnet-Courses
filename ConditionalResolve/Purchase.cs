using ConditionalResolve.Enums;
using ConditionalResolve.Interfaces;

namespace ConditionalResolve;

public class Purchase(Func<Regions, ITaxCalculator> accessor)
{
    public void Checkout(Regions region, double total)
    {
        var taxCalculator = accessor(region);
        var tax = total * taxCalculator.Calculate() / 100;
        var payment = Math.Round(total + tax, 2);
        Console.WriteLine($"Payment made: {payment} rupees");
    }
}
