
namespace Resolver.Coupling
{
    /// <summary>
    /// This implementation is the same as in the Python script.
    /// </summary>
    public class GroupsDifferenceCouplingProvider : ICouplingProvider<decimal, decimal>
    {
        public decimal GetCoupling(decimal item1, decimal item2)
        {
            return 2 * item1 * item2;
        }
    }
}