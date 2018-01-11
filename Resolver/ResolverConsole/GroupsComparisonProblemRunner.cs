using System;
using System.Collections.Generic;
using System.IO;
using Resolver.API;
using Resolver.Bias;
using Resolver.Convertion;
using Resolver.Coupling;
using Resolver.Facade;
using Resolver.Filters;
using Resolver.Models.BinaryGroup;
using Resolver.Models.Responses;
using Resolver.QuantumResolving;
using Resolver.Services.Configuration;
using Resolver.Services.Files;
using Resolver.Services.Process;

namespace ResolverConsole
{
    /// <summary>
    /// This is the same as the IsakovWrapper python script.
    /// I didn't want to have a dependency on the Python script, and decided to implement it myself using the same architecture.
    /// </summary>
    public class GroupsComparisonProblemRunner
    {
        /// <summary>
        /// Creates configuration, registers instances, runs the API and returns result 
        /// </summary>
        /// <param name="input">parsed user's input</param>
        /// <returns>Calculated and resolved response</returns>
        public IResponse<IEnumerable<IBinaryGroup<decimal>>> Run(decimal[] input)
        {
            if (input == null) return null;
            var groupsComparisonAPI = CreateGroupsComparisonAPI(GetConfiguration()); //This is the same thing as the Python script, but in the current's framework implementation.
            return groupsComparisonAPI.Resolve(input, ResultsFilters.GroupsLengthMustBeEqual);
        }
        
        /// <summary>
        /// Creates the Groups Sums Comparison usecase API.
        /// </summary>
        /// <param name="configuration">Configuration provider</param>
        /// <returns>The appropriate for this usecase API.</returns>
        private IQubitsCalculationAPI<decimal> CreateGroupsComparisonAPI(IConfigurationProvider configuration)
        {
            var isakovProcessPath = configuration.GetValueByCurrentPlatform(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_CONFIG_KEY);
            var isakovWorkingDir =
                configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_WORKING_DIRECTORY_CONFIG_KEY);
            var processArgs = configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_ARGS_CONFIG_KEY);

            var api = new QubitsCalculationAPI<decimal, int, decimal, decimal>(
                new QuantumDataExtractionFacade<decimal, decimal, decimal>(new GroupsDifferenceCouplingProvider(),
                    new DefaultValueBiasProvider<decimal, decimal>()),
                new IsakovScriptQubitsResolver<decimal>(new ProcessService(), isakovWorkingDir, isakovProcessPath, processArgs, configuration.GetValue(ConfigurationKeys.ISAKOV_INPUT_FILE_NAME),
                    new SimpleFileService()),
                new QubitsToGroupsConverter<decimal>());
            return api;
        }
        
        /// <summary>
        /// Demo configuration for this usecase.
        /// </summary>
        /// <returns></returns>
        private IConfigurationProvider GetConfiguration()
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