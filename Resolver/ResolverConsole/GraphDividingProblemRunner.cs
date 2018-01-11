using System.Collections.Generic;
using System.IO;
using Resolver.API;
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
using Resolver.Services.Data;
using Resolver.Services.Files;
using Resolver.Services.Process;

namespace ResolverConsole
{
    /// <summary>
    /// The actual coding challange is run from here.
    /// </summary>
    public class GraphDividingProblemRunner
    {
        /// <summary>
        /// Creates configuration, registers instances, runs the API and returns result
        /// </summary>
        /// <param name="input">Parsed user's input</param>
        /// <returns>Result of Qubits resolving</returns>
        public IResponse<IEnumerable<IBinaryGroup<INode<decimal>>>> Run(IDictionary<decimal, INode<decimal>> input)
        {
            if (input == null) return null;
            var graphRootElement = input[0]; //This is element with value 0, which I treat as the root.
            var graphDivisionAPI = CreateGraphDivisionAPI(graphRootElement , GetConfiguration()); 
            return graphDivisionAPI.Resolve(input.Values, ResultsFilters.GroupsLengthMustBeEqual, 1);
        }
        
        /// <summary>
        /// Imagine we have a Container (Castle, Zenject, whatever) that holds all of our instances based on their interface.
        /// For example and testing purposes, I simply create new objects here, but ALL the classes and APIs expect their dependencies to be injected as interfaces.
        /// </summary>
        /// <param name="root">Root user's object</param>
        /// <param name="configuration">Configuration reader</param>
        /// <returns>The Graph division API</returns>
        private IQubitsCalculationAPI<INode<decimal>> CreateGraphDivisionAPI(INode<decimal> root, IConfigurationProvider configuration)
        {
            var isakovProcessPath = configuration.GetValueByCurrentPlatform(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_CONFIG_KEY);
            var isakovWorkingDir =
                configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_WORKING_DIRECTORY_CONFIG_KEY);
            var processArgs = configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_ARGS_CONFIG_KEY);

            var api = new QubitsCalculationAPI<INode<decimal>, int, decimal, decimal>(
                new QuantumDataExtractionFacade<INode<decimal>, decimal, decimal>(new GraphTraversalCouplingProvider(new RecursiveNodeTraverser<decimal>(root)),
                    new DefaultValueBiasProvider<INode<decimal>, decimal>()),
                new IsakovScriptQubitsResolver<INode<decimal>>(new ProcessService(), isakovWorkingDir, isakovProcessPath, processArgs, configuration.GetValue(ConfigurationKeys.ISAKOV_INPUT_FILE_NAME),
                    new SimpleFileService()),
                new QubitsToGroupsConverter<INode<decimal>>());
            return api;
        }

        /// <summary>
        /// Demo configuration.
        /// </summary>
        /// <returns></returns>
        private static IConfigurationProvider GetConfiguration()
        {
            var config = new DemoMemoryConfiguration();
            var latticeFile = "IsakovSolver.lattice";
            config.Add(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_CONFIG_KEY, Path.Combine("Scripts","isakov_win.exe"));
            config.Add(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_CONFIG_KEY+"_OSX", Path.Combine("Scripts", "isakov_mac"));
            config.Add(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_CONFIG_KEY+"_UNIX", Path.Combine("Scripts", "isakov_linux"));
            config.Add(ConfigurationKeys.ISAKOV_INPUT_FILE_NAME, latticeFile);
            config.Add(ConfigurationKeys.ISAKOV_RESOLVER_WORKING_DIRECTORY_CONFIG_KEY, "Scripts");
            config.Add(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_ARGS_CONFIG_KEY, "-s 100 -r 100000 -l "+latticeFile);
            return config;
        }
    }
}