using System.Collections.Generic;

namespace Resolver.Models.Nodes
{
    /// <summary>
    /// Describes a Graph node.
    /// </summary>
    /// <typeparam name="T">Type of data in the node.</typeparam>
    public interface INode<T>
    {
        IEnumerable<INode<T>> Connections { get; }
        T Value { get; }
        void AddConnection(INode<T> connection);
        void RemoveConnection(INode<T> connection);
    }
}