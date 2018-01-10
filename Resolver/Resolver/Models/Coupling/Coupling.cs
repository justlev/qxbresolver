namespace Resolver.Models.Coupling
{
    public class Coupling<ElementIDType, CouplingValueType> : ICoupling<ElementIDType, CouplingValueType>
    {
        public ElementIDType OriginalElementID { get; }
        public ElementIDType CoupledElementId { get; }
        public CouplingValueType CouplingValue { get; }

        public Coupling(ElementIDType originalElementId, ElementIDType coupledElementId, CouplingValueType couplingValue)
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