namespace Resolver.Bias
{
    /// <summary>
    /// This implementation can be used when there's NO bias value.
    /// You can also make another implementation, that will perform some actions and return an appropriate value.
    /// </summary>
    /// <typeparam name="InputType"></typeparam>
    /// <typeparam name="BiasValueType"></typeparam>
    public class DefaultValueBiasProvider<InputType, BiasValueType> : IBiasProvider<InputType, BiasValueType>
    {
        public BiasValueType GetBias(InputType num1)
        {
            return default(BiasValueType);
        }
    }
}