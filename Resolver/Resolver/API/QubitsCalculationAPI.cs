using System;
using System.Collections.Generic;
using System.Linq;
using Resolver.Convertion;
using Resolver.Facade;
using Resolver.Models.BinaryGroup;
using Resolver.Models.Responses;
using Resolver.QuantumResolving;

namespace Resolver.API
{
    /// <summary>
    /// Simple implementation of the API.
    /// Gets user's input, extracts the bias and couplings from it, performs computations using a Qubits resolver and returns a response object.
    /// </summary>
    /// <typeparam name="InputType">User's input type</typeparam>
    /// <typeparam name="InputIDType">Type of value that identifies one item from the input array. Int index usually.</typeparam>
    /// <typeparam name="BiasValueType">The type that is used to save the Bias value.</typeparam>
    /// <typeparam name="CouplingValueType">The type that is used to save the coupling.</typeparam>
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

        /// <summary>
        /// Gets the optimal solution based on user's input, maxResults and filter.
        /// </summary>
        /// <param name="input">User's input</param>
        /// <param name="qubitsResultsFilter">Optional. A filter to filter out the results.</param>
        /// <param name="maxResults">Maximum amount of results to return. -1 as default for unlimited amount.</param>
        /// <returns></returns>
        public IResponse<IEnumerable<IBinaryGroup<InputType>>> Resolve(IEnumerable<InputType> input, Func<IEnumerable<short>, bool> qubitsResultsFilter = null, int maxResults = -1)
        {
            if (GetBreakingUsecasesResult(input, out var response)) return response; //If input is broken or can be resolved immediately, do it and return.

            var couplingsAndBiases = _dataExtractionFacade.GetCouplingsAndBiases(input);  //Extract couplings and biases
                                
            var qubitsResults = _resolver.Resolve(input, couplingsAndBiases.Biases, couplingsAndBiases.Couplings);  //Pass extracted data to resolver and get the result

            var finalGroups = _qubitsToGroupsConverter.DivideInputIntoGroupsByQubits(input, qubitsResults.Select(item => item.Qubits), maxResults, qubitsResultsFilter); //Convert result to groups

            return CreateResponseFromGroups(finalGroups); //Wrap the groups into a Response object with error code and message if neccesary.
        }

        /// <summary>
        /// Create a Response object from the resolved output.
        /// </summary>
        /// <param name="groups"></param>
        /// <returns>Groups wrapped in a response object.</returns>
        private IResponse<IEnumerable<IBinaryGroup<InputType>>> CreateResponseFromGroups(IEnumerable<IBinaryGroup<InputType>> groups)
        {
            if (!groups.Any())
            {
                return new GeneralResponse<IEnumerable<IBinaryGroup<InputType>>>(null, 400, "No matching group was found.");
            }
            return new GeneralResponse<IEnumerable<IBinaryGroup<InputType>>>(groups);
        }

        private bool GetBreakingUsecasesResult(IEnumerable<InputType> input, out IResponse<IEnumerable<IBinaryGroup<InputType>>> response)
        {
            response = null;
            if (input == null || !input.Any() || input.Count() == 1)
            {
                response = new GeneralResponse<IEnumerable<IBinaryGroup<InputType>>>(null, 400, "The input was null/empty.");
                return true;
            }

            if (input.Count() == 2)
            {
                var group = new BinaryGroup<InputType>();
                group.AddToGroup1(input.First());
                group.AddToGroup2(input.ElementAt(1));
                    response = new GeneralResponse<IEnumerable<IBinaryGroup<InputType>>>(
                        new List<IBinaryGroup<InputType>> {group}, 200);
                    return true;
            }

            return false;
        }
    }
}