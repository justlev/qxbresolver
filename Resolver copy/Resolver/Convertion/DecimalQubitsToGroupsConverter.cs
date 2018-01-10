using System;
using System.Collections.Generic;
using System.Linq;
using Resolver.Models.BinaryGroup;

namespace Resolver.Convertion
{
    public class DecimalQubitsToGroupsConverter : IQubitsToGroupsConverter<decimal>
    {
        public IEnumerable<IBinaryGroup<decimal>> DivideInputIntoGroupsByQubits(IEnumerable<decimal> originalInput, IEnumerable<IEnumerable<short>> qubitsGroups,
            int maxResultsCount = -1, Func<IEnumerable<short>, bool> qubitsResultsFilter = null)
        {
            var toReturn = new List<IBinaryGroup<decimal>>();
            
            for (var i = 0;i<qubitsGroups.Count();i++)
            {
                var qubits = qubitsGroups.ElementAt(i);
                var groupIsValid = qubitsResultsFilter?.Invoke(qubits) ?? true;
                if (!groupIsValid) continue;
                
                toReturn.Add(GetGroup(originalInput, qubits));
                
                if (maxResultsCount != -1 && toReturn.Count == maxResultsCount)
                {
                    return toReturn;
                }
            }

            return toReturn;
        }

        private IBinaryGroup<decimal> GetGroup(IEnumerable<decimal> originalInput, IEnumerable<short> qubits)
        {
            var group = new DecimalBinaryGroup();
            for (var i = 0; i < qubits.Count(); i++)
            {
                if (qubits.ElementAt(i) == 1)
                {
                    group.AddToGroup1(originalInput.ElementAt(i));
                }
                else
                {
                    group.AddToGroup2(originalInput.ElementAt(i));
                }
            }

            return group;
        }
    }
}