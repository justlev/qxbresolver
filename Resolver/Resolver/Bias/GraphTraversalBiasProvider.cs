using Resolver.Models.Nodes;

namespace Resolver.Bias
{
    public class GraphTraversalBiasProvider : IBiasProvider<INode<decimal>, decimal>
    {
        public decimal GetBias(INode<decimal> num1, INode<decimal> num2)
        {
            return 0;
        }
    }
}