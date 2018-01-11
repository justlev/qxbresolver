using System.Collections.Generic;

namespace Resolver.Models.Resolving
{
    /// <summary>
    /// The resolved response description. Each response will have Energy, Occurences and the Qubits themselves.
    /// </summary>
    public interface IQubitsResolvingResponse
    {
        decimal Energy { get; }
        IEnumerable<short> Qubits { get; }
        long Occurences { get; }
    }
}