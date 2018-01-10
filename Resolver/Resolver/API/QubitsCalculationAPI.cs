using System;
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
    public class QubitsCalculationAPI<InputType, InputIDType, BiasValueType, CouplingValueType> : IQubitsCalculationAPI<InputType>
    {
        //The following are private properties that might be injected via a container or from the constructor.
        //In this scenario, they are injected via constructor.
        private IQuantumDataExtractionFacade<InputType, InputIDType, BiasValueType, CouplingValueType> _dataExtractionFacade;
        private IQubitsResolver<InputType, InputIDType, BiasValueType, CouplingValueType> _resolver;
        private IQubitsToGroupsConverter<InputType> _qubitsToGroupsConverter;
        private Func<IEnumerable<short>, bool> _qubitsResultsFilter;

        public QubitsCalculationAPI(
            IQuantumDataExtractionFacade<InputType, InputIDType, BiasValueType, CouplingValueType> dataExtractionFacade,
            IQubitsResolver<InputType, InputIDType, BiasValueType, CouplingValueType> resolver,
            IQubitsToGroupsConverter<InputType> qubitsToGroupsConverter)
        {
            _dataExtractionFacade = dataExtractionFacade;
            _resolver = resolver;
            _qubitsToGroupsConverter = qubitsToGroupsConverter;
        }

        public IResponse<IBinaryGroup<InputType>> GetBestEqualGroups(IEnumerable<InputType> input, Func<IEnumerable<short>, bool> qubitsResultsFilter = null)
        {
            if (GetBreakingUsecasesResult(input, out var response)) return response;

            var couplingsAndBiases = _dataExtractionFacade.GetCouplingsAndBiases(input);
                                
            var qubitsResults = _resolver.Resolve(input, couplingsAndBiases.Biases, couplingsAndBiases.Couplings);

            var finalGroups = _qubitsToGroupsConverter.DivideInputIntoGroupsByQubits(input, qubitsResults.Select(item => item.Qubits), 1, qubitsResultsFilter);

            return CreateResponseFromGroups(finalGroups);
        }

        private IResponse<IBinaryGroup<InputType>> CreateResponseFromGroups(IEnumerable<IBinaryGroup<InputType>> finalGroups)
        {
            if (!finalGroups.Any())
            {
                return new GeneralResponse<IBinaryGroup<InputType>>(null, 400, "No matching group was found.");
            }
            return new GeneralResponse<IBinaryGroup<InputType>>(finalGroups.First());
        }

        private bool GetBreakingUsecasesResult(IEnumerable<InputType> input, out IResponse<IBinaryGroup<InputType>> response)
        {
            response = null;
            if (input == null || !input.Any())
            {
                response = new GeneralResponse<IBinaryGroup<InputType>>(null, 400, "The input was null/empty.");
                return true;
            }

            //TODO: Fix this, since it doesn't work when root node is sent.
            return false;
            if (input.Count() < 3)
            {
                var group = new BinaryGroup<InputType>();
                group.AddToGroup1(input.First());
                group.AddToGroup2(input.ElementAt(1));
                    response = new GeneralResponse<IBinaryGroup<InputType>>(
                        group, 200);
                    return true;
            }

            return false;
        }
    }
}