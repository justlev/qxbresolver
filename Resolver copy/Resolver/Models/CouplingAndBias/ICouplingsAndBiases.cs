using System.Collections.Generic;
using Resolver.Models.Bias;
using Resolver.Models.Coupling;

namespace Resolver.CouplingAndBias
{
    /// <summary>
    /// This interface simply contains an Enumerable of Couplings and Enumerable of Biases.
    /// The only reason for this interface is to make the code more readable.
    /// </summary>
    /// <typeparam name="TInputType"></typeparam>
    public interface ICouplingsAndBiases<TInputType>
    {
        IEnumerable<ICoupling<TInputType>> Couplings { get; }
        IEnumerable<IBias<TInputType>> Biases { get; }

        void AddCoupling(TInputType couplingFrom, TInputType couplingTo, decimal couplingValue);
        void AddBias(TInputType element, decimal value);
    }
}