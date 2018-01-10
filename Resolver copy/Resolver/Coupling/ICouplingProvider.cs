namespace Resolver.Coupling
{
    public interface ICouplingProvider<TInput>
    {
        decimal GetCoupling(TInput num1, TInput num2);
    }
}