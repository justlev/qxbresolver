namespace Resolver.Models.Bias
{
    public class Bias<InputIDType, BiasValueType> : IBias<InputIDType, BiasValueType>
    {
        public InputIDType ElementID { get; }
        public BiasValueType BiasValue { get; }

        public Bias(InputIDType elementId, BiasValueType biasValue)
        {
            ElementID = elementId;
            BiasValue = biasValue;
        }

        public override string ToString()
        {
            return ElementID + " " + ElementID + " " + BiasValue;
        }
    }
}