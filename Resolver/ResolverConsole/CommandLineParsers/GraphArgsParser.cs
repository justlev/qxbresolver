using System;
using System.Collections.Generic;
using Resolver.Models.Nodes;

namespace ResolverConsole.CommandLineParsers
{
    /// <summary>
    /// User's input is [procName, 1, 3, 2, 4], parses it to Node1 --> Node3,  Node2 --> Node4.
    /// </summary>
    public class GraphArgsParser : IParser<IDictionary<decimal, INode<decimal>>>
    {
        public IDictionary<decimal, INode<decimal>> Parse(string[] args)
        {
            var vertexToNode = new Dictionary<decimal, INode<decimal>>();
            for (var i = 1; i < args.Length ; i+=2)
            {
                decimal from;
                if (!decimal.TryParse(args[i], out from))
                {
                    Console.WriteLine(string.Format("Input {0} was not a decimal number. Aborting.", args[i]));
                    return null;
                }

                decimal to;
                if (!decimal.TryParse(args[i + 1], out to))
                {
                    Console.WriteLine(string.Format("Input {0} was not a decimal number. Aborting.", args[i + 1]));
                    return null;
                }

                if (!vertexToNode.ContainsKey(to))
                {
                    vertexToNode[to] = new Node<decimal>(to);
                }

                if (!vertexToNode.ContainsKey(from))
                {
                    vertexToNode[from] = new Node<decimal>(from);
                }

                if (to == 0)
                {
                    vertexToNode[to].AddConnection(vertexToNode[from]);
                }
                else
                {
                    vertexToNode[from].AddConnection(vertexToNode[to]);
                }
            }

            return vertexToNode;
        }
    }
}