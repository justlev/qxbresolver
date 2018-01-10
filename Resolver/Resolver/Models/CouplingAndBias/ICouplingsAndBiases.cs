using System.Collections.Generic;
using Resolver.Models.Bias;
using Resolver.Models.Coupling;

namespace Resolver.CouplingAndBias
{
    /// <summary>
    /// This interface simply contains an Enumerable of Couplings and Enumerable of Biases.
    /// The only reason for this interface is to make the code more readable.
    /// </summary>
    public interface ICouplingsAndBiases<ElementIDType, BiasValueType, CouplingValueType>
    {
        IEnumerable<ICoupling<ElementIDType, CouplingValueType>> Couplings { get; }
        IEnumerable<IBias<ElementIDType, BiasValueType>> Biases { get; }

        void AddCoupling(ElementIDType couplingFrom, ElementIDType couplingTo, CouplingValueType couplingValue);
        void AddBias(ElementIDType element, BiasValueType value);
    }
}