using System;

namespace Resolver.Coupling
{
    public class SimpleCouplingProvider : ICouplingProvider<decimal>
    {
        public decimal GetCoupling(decimal num1, decimal num2)
        {
            return 2 * num1 * num2;
        }
    }
}