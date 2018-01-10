namespace Resolver.Models.Coupling
{
    /// <summary>
    /// Describes a generic coupling model.
    /// </summary>
    /// <typeparam name="ElementIndexType"></typeparam>
    public interface ICoupling<ElementIndexType, CouplingValueType>
    {
        ElementIndexType OriginalElementID { get; }
        ElementIndexType CoupledElementId { get; }
        CouplingValueType CouplingValue { get; }
    }
}