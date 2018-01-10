using System;
using System.Collections.Generic;
using Resolver.Models.Bias;
using Resolver.Models.Coupling;

namespace Resolver.CouplingAndBias
{
    public class CouplingsAndBiases<ElementIDType, BiasValueType, CouplingValueType> : ICouplingsAndBiases<ElementIDType, BiasValueType, CouplingValueType>, IDisposable
    {
        public IEnumerable<ICoupling<ElementIDType, CouplingValueType>> Couplings
        {
            get { return _couplings; }
        }

        public IEnumerable<IBias<ElementIDType, BiasValueType>> Biases
        {
            get { return _biases; }
        }

        private IList<ICoupling<ElementIDType, CouplingValueType>> _couplings;
        private IList<IBias<ElementIDType, BiasValueType>> _biases;

        public CouplingsAndBiases()
        {
            _couplings = new List<ICoupling<ElementIDType, CouplingValueType>>();
            _biases = new List<IBias<ElementIDType, BiasValueType>>();
        }

        public void AddCoupling(ElementIDType couplingFrom, ElementIDType couplingTo, CouplingValueType couplingValue)
        {
            _couplings.Add(new Coupling<ElementIDType, CouplingValueType>(couplingFrom, couplingTo, couplingValue));
        }

        public void AddBias(ElementIDType element, BiasValueType value)
        {
            _biases.Add(new Bias<ElementIDType, BiasValueType>(element, value));
        }

        public void Dispose()
        {
            _biases.Clear();
            _couplings.Clear();
        }
    }
}