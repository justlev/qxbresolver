using System.Collections.Generic;
using System.Linq;

namespace Resolver.Filters
{
    /// <summary>
    /// Static class that will contain optional filters for the resolved values.
    /// Maybe we only want groups that have equal amount of elements? maybe something else?
    /// Here is the place to define those. 
    /// </summary>
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
            
            var firstItemCount = dictionary.ElementAt(0).Value;
            
            var success = true;
            foreach (var count in dictionary.Values)
            {
                if (count == firstItemCount) continue;
                
                success = false;
                break;
            }
            dictionary.Clear();
            return success;
        }
    }
}