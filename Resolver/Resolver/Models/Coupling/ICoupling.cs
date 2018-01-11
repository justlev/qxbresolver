namespace Resolver.Models.Coupling
{
    /// <summary>
    /// Describes Coupling between two objects.
    /// </summary>
    /// <typeparam name="ElementIDType">The type of value used to index the element. (array index for example)</typeparam>
    /// <typeparam name="CouplingValueType">Type of value that holds the coupling.</typeparam>
    public interface ICoupling<ElementIDType, CouplingValueType>
    {
        ElementIDType OriginalElementID { get; }
        ElementIDType CoupledElementId { get; }
        CouplingValueType CouplingValue { get; }
    }
}