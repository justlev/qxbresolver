namespace Resolver.Models.Bias
{
    public class Bias<TInputType> : IBias<TInputType>
    {
        public TInputType ElementID { get; }
        public decimal BiasValue { get; }

        public Bias(TInputType elementId, decimal biasValue)
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