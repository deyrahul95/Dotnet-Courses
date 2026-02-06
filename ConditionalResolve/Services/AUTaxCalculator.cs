using ConditionalResolve.Interfaces;

namespace ConditionalResolve.Services;

public class AUTaxCalculator : ITaxCalculator
{
    public int Calculate()
    {
        return 10;
    }
}
