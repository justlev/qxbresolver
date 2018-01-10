namespace Resolver.Bias
{
    public class GroupsDifferenceBiasProvider : IBiasProvider<decimal, decimal>
    {
        public decimal GetBias(decimal num1, decimal num2)
        {
            return 0; //Current implementation, can be any other logic.
        }
    }
}