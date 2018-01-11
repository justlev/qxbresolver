namespace Resolver.Bias
{
    public interface IBiasProvider<InputType, BiasValueType>
    {
        BiasValueType GetBias(InputType num1);
    }
}