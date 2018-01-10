using System.Collections.Generic;
using Resolver.Models.Bias;
using Resolver.Models.Coupling;
using Resolver.Models.Resolving;

namespace Resolver.QuantumResolving
{
    public interface IQubitsResolver<TInput>
    {
        IEnumerable<IQubitsResolvingResponse> Resolve(IEnumerable<TInput> inputNumbers, IEnumerable<IBias<TInput>> biases,
            IEnumerable<ICoupling<TInput>> numToCouplings);
    }
}