namespace Resolver.Models.Bias
{
    /// <summary>
    /// Describes a Bias of a given object.
    /// </summary>
    /// <typeparam name="InputIDType"></typeparam>
    public interface IBias<InputIDType, BiasValueType>
    {
        InputIDType ElementID { get; }
        BiasValueType BiasValue { get; } //Can it be NOT short?
    }
}