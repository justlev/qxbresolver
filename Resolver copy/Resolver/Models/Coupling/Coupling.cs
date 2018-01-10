namespace Resolver.Models.Coupling
{
    public class Coupling<TDataType> : ICoupling<TDataType>
    {
        public TDataType OriginalElementID { get; }
        public TDataType CoupledElementId { get; }
        public decimal CouplingValue { get; }

        public Coupling(TDataType originalElementId, TDataType coupledElementId, decimal couplingValue)
        {
            OriginalElementID = originalElementId;
            CoupledElementId = coupledElementId;
            CouplingValue = couplingValue;
        }
        
        public override string ToString()
        {
            return OriginalElementID + " " + CoupledElementId + " " + CouplingValue;
        }
    }
}