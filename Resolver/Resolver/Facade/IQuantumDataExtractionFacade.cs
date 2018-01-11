using System.Collections.Generic;
using Resolver.CouplingAndBias;

namespace Resolver.Facade
{
    /// <summary>
    /// Facade made for convenience.
    /// No matter what the actual calculation is, the biases and couplings should be extracted. This interface is responsible for combining those two common actions.
    /// </summary>
    /// <typeparam name="TInputType"></typeparam>
    public interface IQuantumDataExtractionFacade<InputType, InputIDType, BiasValueType, CouplingValueType>
    {
        ICouplingsAndBiases<InputIDType, BiasValueType, CouplingValueType> GetCouplingsAndBiases(IEnumerable<InputType> input);
    }
}