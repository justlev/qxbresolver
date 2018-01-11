using System.Collections.Generic;

namespace Resolver.Models.Resolving
{
    public class IsakovScriptResponse : IQubitsResolvingResponse
    {
        public decimal Energy { get; }
        public IEnumerable<short> Qubits { get; }
        public ulong Occurences { get; }

        public IsakovScriptResponse(decimal energy, IEnumerable<short> qubits, ulong occurences)
        {
            Energy = energy;
            Qubits = qubits;
            Occurences = occurences;
        }
    }
}