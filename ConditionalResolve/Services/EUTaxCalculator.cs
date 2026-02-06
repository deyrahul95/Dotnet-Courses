using ConditionalResolve.Interfaces;

namespace ConditionalResolve.Services;

public class EUTaxCalculator : ITaxCalculator
{
    public int Calculate()
    {
        return 20;
    }
}
