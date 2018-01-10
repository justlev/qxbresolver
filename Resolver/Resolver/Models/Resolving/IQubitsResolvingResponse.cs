using System.Collections.Generic;

namespace Resolver.Models.Resolving
{
    public interface IQubitsResolvingResponse
    {
        decimal Energy { get; }
        IEnumerable<short> Qubits { get; }
        long Occurences { get; }
    }
}