using System.Collections.Generic;
using System.Linq;
using Resolver.Bias;
using Resolver.Coupling;
using Resolver.CouplingAndBias;

namespace Resolver.Facade
{
    public class QuantumDataExtractionFacade<InputType, BiasValueType, CouplingValueType> : IQuantumDataExtractionFacade<InputType, int, BiasValueType, CouplingValueType>
    {
        private ICouplingProvider<InputType, CouplingValueType> _couplingsProvider;
        private IBiasProvider<InputType, BiasValueType> _biasProvider;

        public QuantumDataExtractionFacade(ICouplingProvider<InputType, CouplingValueType> couplingsProvider, IBiasProvider<InputType, BiasValueType> biasProvider)
        {
            _couplingsProvider = couplingsProvider;
            _biasProvider = biasProvider;
        }

        public ICouplingsAndBiases<int, BiasValueType, CouplingValueType> GetCouplingsAndBiases(IEnumerable<InputType> input)
        {
            var inputLength = input.Count();
            var response = new CouplingsAndBiases<int, BiasValueType, CouplingValueType>();
            
            for (var i = 0; i < input.Count(); i++)
            {
                var currentElement = input.ElementAt(i);
                var bias = _biasProvider.GetBias(currentElement, currentElement); 
                response.AddBias(i, bias);
                for (var j = i+1; j < input.Count(); j++)
                {
                    var nextElement = input.ElementAt(j);
                    var coupling = _couplingsProvider.GetCoupling(currentElement, nextElement);
                    response.AddCoupling(i, j, coupling);
                }
            }
            return response;
        }
    }
}