using System.Collections.Generic;
using Resolver.CouplingAndBias;

namespace Resolver.Facade
{
    /// <summary>
    /// Common data extraction functionality should go to this facade.
    /// </summary>
    /// <typeparam name="TInputType"></typeparam>
    public interface IQuantumDataExtractionFacade<InputType, InputIDType, BiasValueType, CouplingValueType>
    {
        ICouplingsAndBiases<InputIDType, BiasValueType, CouplingValueType> GetCouplingsAndBiases(IEnumerable<InputType> input);
    }
}