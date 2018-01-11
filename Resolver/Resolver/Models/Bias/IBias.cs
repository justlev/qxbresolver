namespace Resolver.Models.Bias
{
    /// <summary>
    /// Describes a Bias between objects.
    /// </summary>
    /// <typeparam name="InputIDType">Type of value used to identifty user's input. (int index in an array for example)</typeparam>
    /// <typeparam name="BiasValueType">Type of value that holds the Bias. Decimal, double, unsigned long, object, whatever you want it to be.</typeparam>
    public interface IBias<InputIDType, BiasValueType>
    {
        InputIDType ElementID { get; }
        BiasValueType BiasValue { get; } //Can it be NOT short?
    }
}