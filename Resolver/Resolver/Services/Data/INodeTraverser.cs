using System;
using Resolver.Models.Nodes;

namespace Resolver.Services.Data
{
    /// <summary>
    /// Interface describes a class that traverses between nodes.
    /// For our case, it currently has only one method, which finds the distance between two nodes in a graph.
    /// </summary>
    /// <typeparam name="T">Type of value in the Node. Must be equatable.</typeparam>
    public interface INodeTraverser<T> where T : IEquatable<T>
    {
        int GetLengthBetweenNodes(INode<T> item1, INode<T> item2);
    }
}