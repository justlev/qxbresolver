using System;
using Resolver.Models.Nodes;

namespace Resolver.Services.Data
{
    public class RecursiveNodeTraverser<T> : INodeTraverser<T> where T : IEquatable<T>
    {
        private INode<T> _root;

        public RecursiveNodeTraverser(INode<T> root)
        {
            _root = root;
        }
        
        public int GetLengthBetweenNodes(INode<T> item1, INode<T> item2)
        {
            var found = false;
            var result = RecursiveCalculatePathBetweenItems(item1, item2.Value, ref found, 0);
            if (found) return result;
            result = RecursiveCalculatePathBetweenItems(item2, item1.Value, ref found, 0);
            if (found) return result;
            return -1;
        }
        
        private int RecursiveCalculatePathBetweenItems(INode<T> root, T target, ref bool found, int count)
        {
            if (root.Value.Equals(target))
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