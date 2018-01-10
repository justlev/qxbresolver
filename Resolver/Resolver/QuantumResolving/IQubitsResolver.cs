using System.Collections.Generic;
using Resolver.Models.Bias;
using Resolver.Models.Coupling;
using Resolver.Models.Resolving;

namespace Resolver.QuantumResolving
{
    public interface IQubitsResolver<InputType, InputIDType, BiasValueType, CouplingValueType>
    {
        IEnumerable<IQubitsResolvingResponse> Resolve(IEnumerable<InputType> inputNumbers, IEnumerable<IBias<InputIDType, BiasValueType>> biases,
            IEnumerable<ICoupling<InputIDType, CouplingValueType>> numToCouplings);
    }
}