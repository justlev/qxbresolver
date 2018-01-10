using System.Collections.Generic;
using System.Linq;

namespace Resolver.Filters
{
    public static class ResultsFilters
    {
        public static bool GroupsLengthMustBeEqual(IEnumerable<short> qubits)
        {
            var dictionary = new Dictionary<int, int>();
            foreach (var qubit in qubits)
            {
                if (!dictionary.ContainsKey(qubit))
                {
                    dictionary[qubit] = 0;
                }

                dictionary[qubit]++;
            }

            if (dictionary.Count <= 1)
            {
                dictionary.Clear();
                return false;
            }
            
            var firstValue = dictionary.ElementAt(0).Value;
            
            var success = true;
            foreach (var value in dictionary.Values)
            {
                if (value != firstValue)
                {
                    success = false;
                    break;
                }
            }
            dictionary.Clear();
            return success;
        }
    }
}