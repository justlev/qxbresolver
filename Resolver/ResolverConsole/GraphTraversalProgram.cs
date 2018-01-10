using System.Collections.Generic;
using Resolver.Bias;
using Resolver.Convertion;
using Resolver.Coupling;
using Resolver.Facade;
using Resolver.Filters;
using Resolver.Models.BinaryGroup;
using Resolver.Models.Nodes;
using Resolver.Models.Responses;
using Resolver.QuantumResolving;
using Resolver.Services.Configuration;
using Resolver.Services.Files;
using Resolver.Services.Process;

namespace ResolverConsole
{
    public static class GraphTraversalProgram
    {
        /// <summary>
        /// Creates an API.
        /// Can be a Rest API, can be a dll library published, can be any implementation.
        /// </summary>
        private static IQubitsCalculationAPI<INode<decimal>> CreateGraphDivisionAPI(INode<decimal> root, IConfigurationProvider configuration)
        {
            var isakovProcessPath = configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_CONFIG_KEY);
            var isakovWorkingDir =
                configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_WORKING_DIRECTORY_CONFIG_KEY);
            var processArgs = configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_ARGS_CONFIG_KEY);

            var api = new QubitsCalculationAPI<INode<decimal>, int, decimal, decimal>(
                new QuantumDataExtractionFacade<INode<decimal>, decimal, decimal>(new GraphTraversalCouplingProvider(root),
                    new GraphTraversalBiasProvider()),
                new IsakovScriptQubitsResolver<INode<decimal>>(new ProcessService(), isakovWorkingDir, isakovProcessPath, processArgs,
                    new SimpleFileService()),
                new QubitsToGroupsConverter<INode<decimal>>());
            return api;
        }

        public static IResponse<IBinaryGroup<INode<decimal>>> Run(IDictionary<decimal, INode<decimal>> input)
        {
            if (input == null) return null;
            
            var graphDivisionAPI = CreateGraphDivisionAPI(input[0], new DemoMemoryConfiguration()); 
            return graphDivisionAPI.GetBestEqualGroups(input.Values, ResultsFilters.GroupsLengthMustBeEqual);
        }
    }
}