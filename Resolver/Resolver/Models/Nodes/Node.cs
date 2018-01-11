using System.Collections.Generic;
using System.Linq;

namespace Resolver.Models.Nodes
{
    public class Node<T> : INode<T>
    {
        private List<INode<T>> _connections;
        
        public IEnumerable<INode<T>> Connections
        {
            get { return _connections; }
        }
        
        public T Value { get; }
         
        public Node(T value, params INode<T>[] connections)
        {
            _connections = new List<INode<T>>();
            _connections = connections.ToList();
            Value = value;
        }

        public void AddConnection(INode<T> connection)
        {
            _connections.Add(connection);
        }

        public void RemoveConnection(INode<T> connection)
        {
            if (_connections.Contains(connection))
            {
                _connections.Remove(connection);
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}