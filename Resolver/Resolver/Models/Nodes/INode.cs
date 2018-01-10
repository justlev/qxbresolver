using System.Collections.Generic;

namespace Resolver.Models.Nodes
{
    public interface INode<T>
    {
        IEnumerable<INode<T>> Connections { get; }
        T Value { get; }
        void AddConnection(INode<T> from);
    }
}