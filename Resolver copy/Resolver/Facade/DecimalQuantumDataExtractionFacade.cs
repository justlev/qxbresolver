using System.Collections.Generic;
using System.Linq;
using Resolver.Bias;
using Resolver.Coupling;
using Resolver.CouplingAndBias;

namespace Resolver.Facade
{
    public class DecimalQuantumDataExtractionFacade : IQuantumDataExtractionFacade<decimal>
    {
        private ICouplingProvider<decimal> _couplingsProvider;
        private IBiasProvider<decimal> _biasProvider;

        public DecimalQuantumDataExtractionFacade(ICouplingProvider<decimal> couplingsProvider, IBiasProvider<decimal> biasProvider)
        {
            _couplingsProvider = couplingsProvider;
            _biasProvider = biasProvider;
        }

        public ICouplingsAndBiases<decimal> GetCouplingsAndBiases(IEnumerable<decimal> input)
        {
            var inputLength = input.Count();
            var response = new CouplingsAndBiases<decimal>();
            
            for (var i = 0; i < input.Count(); i++)
            {
                var bias = _biasProvider.GetBias(i, i); 
                response.AddBias(i, bias);
                for (var j = i+1; j < input.Count(); j++)
                {
                    var coupling = _couplingsProvider.GetCoupling(input.ElementAt(i), input.ElementAt(j));
                    response.AddCoupling(i, j, coupling);
                }
            }
            return response;
        }
    }
}