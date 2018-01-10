using Resolver.Models.Nodes;

namespace Resolver.Coupling
{
    /// <summary>
    /// This is the actual task implementation.
    /// </summary>
    public class GraphTraversalCouplingProvider : ICouplingProvider<INode<decimal>, decimal>
    {
        private INode<decimal> _root;

        public GraphTraversalCouplingProvider(INode<decimal> root)
        {
            _root = root;
        }
        
        public decimal GetCoupling(INode<decimal> item1, INode<decimal> item2)
        {
            var found = false;
            var result = RecursiveCalculatePathBetweenItems(item1, item2.Value, ref found, 0);
            if (found) return result;
            result = RecursiveCalculatePathBetweenItems(item2, item1.Value, ref found, 0);
            if (found) return result;
            var fromRootTo1 = RecursiveCalculatePathBetweenItems(_root, item1.Value, ref found, 0);
            found = false;
            var fromRootTo2 = RecursiveCalculatePathBetweenItems(_root, item2.Value, ref found, 0);
            return fromRootTo1 + fromRootTo2;
        }

        private int RecursiveCalculatePathBetweenItems(INode<decimal> root, decimal target, ref bool found, int count)
        {
            if (root.Value == target)
            {
                found = true;
                return count;
            }

            count++;
            foreach (var child in root.Connections)
            {
                var result = RecursiveCalculatePathBetweenItems(child, target, ref found, count);
                if (found) return result;
            }

            if (!found) return -1;
            return count;
        }
    }
}