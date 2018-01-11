namespace Resolver.Coupling
{
    /// <summary>
    /// One of the things that change between usecases it the relation between elements from the user's input.
    /// This interface describes this relation.
    /// </summary>
    /// <typeparam name="InputType">User's input type</typeparam>
    /// <typeparam name="CouplingValueType">Type of value that holds the coupling value. Usually, a decimal, but might become unsigned-value at times.</typeparam>
    public interface ICouplingProvider<InputType, CouplingValueType>
    {
        CouplingValueType GetCoupling(InputType item1, InputType item2);
    }
}