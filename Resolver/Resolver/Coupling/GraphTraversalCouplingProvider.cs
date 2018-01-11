using Resolver.Models.Nodes;
using Resolver.Services.Data;

namespace Resolver.Coupling
{
    /// <summary>
    /// This is the actual task implementation.
    /// </summary>
    public class GraphTraversalCouplingProvider : ICouplingProvider<INode<decimal>, decimal>
    {
        private INodeTraverser<decimal> _nodesTraverser;

        public GraphTraversalCouplingProvider(INodeTraverser<decimal> nodesTraverser)
        {
            _nodesTraverser = nodesTraverser;
        }
        
        public decimal GetCoupling(INode<decimal> item1, INode<decimal> item2)
        {
            return _nodesTraverser.GetLengthBetweenNodes(item1, item2);
        }
    }
}