namespace Resolver.Coupling
{
    public interface ICouplingProvider<InputType, CouplingValueType>
    {
        CouplingValueType GetCoupling(InputType item1, InputType item2);
    }
}