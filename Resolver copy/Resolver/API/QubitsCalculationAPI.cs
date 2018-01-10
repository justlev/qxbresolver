using System.Collections.Generic;
using System.Linq;
using Resolver.Convertion;
using Resolver.Facade;
using Resolver.Models.Responses;
using Resolver.QuantumResolving;

namespace Resolver.Models.BinaryGroup
{
    /// <summary>
    /// Sample implementation of API. Can be a REST api, a SystemCallAPI, etc. It doesn't matter.
    /// </summary>
    public class QubitsCalculationAPI : IQubitsCalculationAPI
    {
        //The following are private properties that might be injected via a container or from the constructor.
        //In this scenario, they are injected via constructor.
        private IQuantumDataExtractionFacade<decimal> _dataExtractionFacade;
        private IQubitsResolver<decimal> _resolver;
        private IQubitsToGroupsConverter<decimal> _qubitsToGroupsConverter;

        public QubitsCalculationAPI(IQuantumDataExtractionFacade<decimal> dataExtractionFacade, IQubitsResolver<decimal> resolver, IQubitsToGroupsConverter<decimal> qubitsToGroupsConverter)
        {
            _dataExtractionFacade = dataExtractionFacade;
            _resolver = resolver;
            _qubitsToGroupsConverter = qubitsToGroupsConverter;
        }

        public IResponse<IBinaryGroup<decimal>> GetBestEqualGroups(IEnumerable<decimal> input)
        {
            if (GetBreakingUsecasesResult(input, out var response)) return response;

            var couplingsAndBiases = _dataExtractionFacade.GetCouplingsAndBiases(input);
                                
            var qubitsResults = _resolver.Resolve(input, couplingsAndBiases.Biases, couplingsAndBiases.Couplings);

            var finalGroups = _qubitsToGroupsConverter.DivideInputIntoGroupsByQubits(input, qubitsResults.Select(item => item.Qubits), 1, ResultsFilters.GroupsLengthMustBeEqual);            

            return GetResponseFromGroup(finalGroups.First());
        }

        private IResponse<IBinaryGroup<decimal>> GetResponseFromGroup(IBinaryGroup<decimal> finalGroups)
        {
            return new GeneralResponse<IBinaryGroup<decimal>>(finalGroups);
        }

        private bool GetBreakingUsecasesResult(IEnumerable<decimal> input, out IResponse<IBinaryGroup<decimal>> response)
        {
            response = null;
            if (input == null || !input.Any())
            {
                response = new GeneralResponse<IBinaryGroup<decimal>>(null, 400, "The input was null/empty.");
                return true;
            }

            if (input.Count() < 3)
            {
                var group = new DecimalBinaryGroup();
                group.AddToGroup1(input.First());
                group.AddToGroup2(input.ElementAt(1));
                    response = new GeneralResponse<IBinaryGroup<decimal>>(
                        group, 200);
                    return true;
            }

            return false;
        }
    }
}