namespace Resolver.Bias
{
    public class DecimalBiasProvider : IBiasProvider<decimal>
    {
        public short GetBias(decimal num1, decimal num2)
        {
            return 0; //TODO: proper bias calculation.
        }
    }
}