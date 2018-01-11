using System.Collections.Generic;
using Resolver.Models.Bias;
using Resolver.Models.Coupling;
using Resolver.Models.Resolving;

namespace Resolver.QuantumResolving
{
    /// <summary>
    /// The main function that does something or invokes something that calculates the qubits based on the user's input, biases and couplings.
    /// </summary>
    /// <typeparam name="InputType"></typeparam>
    /// <typeparam name="InputIDType"></typeparam>
    /// <typeparam name="BiasValueType"></typeparam>
    /// <typeparam name="CouplingValueType"></typeparam>
    public interface IQubitsResolver<InputType, InputIDType, BiasValueType, CouplingValueType>
    {
        IEnumerable<IQubitsResolvingResponse> Resolve(IEnumerable<InputType> inputNumbers, IEnumerable<IBias<InputIDType, BiasValueType>> biases,
            IEnumerable<ICoupling<InputIDType, CouplingValueType>> numToCouplings);
    }
}