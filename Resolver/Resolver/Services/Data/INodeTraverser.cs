using System;
using Resolver.Models.Nodes;

namespace Resolver.Services.Data
{
    /// <summary>
    /// Interface describes a class that knows how to traverse between nodes.
    /// For our case, it only has one method, which finds the distance between two nodes in a graph.
    /// </summary>
    /// <typeparam name="T">Type of value in the Node. Must be equatable.</typeparam>
    public interface INodeTraverser<T> where T : IEquatable<T>
    {
        int GetLengthBetweenNodes(INode<T> item1, INode<T> item2);
    }
}