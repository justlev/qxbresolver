namespace Resolver.Models.Coupling
{
    /// <summary>
    /// Describes a generic coupling model.
    /// </summary>
    /// <typeparam name="TDataType"></typeparam>
    public interface ICoupling<TDataType>
    {
        TDataType OriginalElementID { get; }
        TDataType CoupledElementId { get; }
        decimal CouplingValue { get; }
    }
}