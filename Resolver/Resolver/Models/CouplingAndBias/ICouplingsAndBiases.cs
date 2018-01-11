using System.Collections.Generic;
using Resolver.Models.Bias;
using Resolver.Models.Coupling;

namespace Resolver.CouplingAndBias
{
    /// <summary>
    /// Simple wrapper that has both the couplings and biases.
    /// </summary>
    /// <typeparam name="ElementIDType">Type of element that is used to identify the specific element in the user's input.</typeparam>
    /// <typeparam name="BiasValueType">Type of value that holds the Bias</typeparam>
    /// <typeparam name="CouplingValueType">Type of value that holds the Couplings.</typeparam>
    public interface ICouplingsAndBiases<ElementIDType, BiasValueType, CouplingValueType>
    {
        IEnumerable<ICoupling<ElementIDType, CouplingValueType>> Couplings { get; }
        IEnumerable<IBias<ElementIDType, BiasValueType>> Biases { get; }

        void AddCoupling(ElementIDType couplingFrom, ElementIDType couplingTo, CouplingValueType couplingValue);
        void AddBias(ElementIDType element, BiasValueType value);
    }
}