namespace Resolver.Bias
{
    public interface IBiasProvider<TInput>
    {
        short GetBias(TInput num1, TInput num2);
    }
}