using System.Collections.Generic;
using Resolver.CouplingAndBias;

namespace Resolver.Facade
{
    /// <summary>
    /// Common data extraction functionality should go to this facade.
    /// </summary>
    /// <typeparam name="TInputType"></typeparam>
    public interface IQuantumDataExtractionFacade<TInputType>
    {
        ICouplingsAndBiases<TInputType> GetCouplingsAndBiases(IEnumerable<TInputType> input);
    }
}