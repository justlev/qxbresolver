using System;
using System.Collections.Generic;
using Resolver.Models.Bias;
using Resolver.Models.Coupling;

namespace Resolver.CouplingAndBias
{
    public class CouplingsAndBiases<TInputType> : ICouplingsAndBiases<TInputType>, IDisposable
    {
        public IEnumerable<ICoupling<TInputType>> Couplings
        {
            get { return _couplings; }
        }

        public IEnumerable<IBias<TInputType>> Biases
        {
            get { return _biases; }
        }

        private IList<ICoupling<TInputType>> _couplings;
        private IList<IBias<TInputType>> _biases;

        public CouplingsAndBiases()
        {
            _couplings = new List<ICoupling<TInputType>>();
            _biases = new List<IBias<TInputType>>();
        }

        public void AddCoupling(TInputType couplingFrom, TInputType couplingTo, decimal couplingValue)
        {
            _couplings.Add(new Coupling<TInputType>(couplingFrom, couplingTo, couplingValue));
        }

        public void AddBias(TInputType element, decimal value)
        {
            _biases.Add(new Bias<TInputType>(element, value));
        }

        public void Dispose()
        {
            _biases.Clear();
            _couplings.Clear();
        }
    }
}