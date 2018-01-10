namespace Resolver.Models.Bias
{
    /// <summary>
    /// Describes a Bias of a given object.
    /// </summary>
    /// <typeparam name="TDataType"></typeparam>
    public interface IBias<TDataType>
    {
        TDataType ElementID { get; }
        decimal BiasValue { get; } //Can it be NOT short?
    }
}