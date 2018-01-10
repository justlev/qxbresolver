using System;
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
    public static class GroupsComparisonProgram
    {
        /// <summary>
        /// Creates an API.
        /// Can be a Rest API, can be a dll library published, can be any implementation.
        /// </summary>
        private static IQubitsCalculationAPI<decimal> CreateGroupsComparisonAPI(IConfigurationProvider configuration)
        {
            var isakovProcessPath = configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_CONFIG_KEY);
            var isakovWorkingDir =
                configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_WORKING_DIRECTORY_CONFIG_KEY);
            var processArgs = configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_ARGS_CONFIG_KEY);

            var api = new QubitsCalculationAPI<decimal, int, decimal, decimal>(
                new QuantumDataExtractionFacade<decimal, decimal, decimal>(new GroupsDifferenceCouplingProvider(),
                    new GroupsDifferenceBiasProvider()),
                new IsakovScriptQubitsResolver<decimal>(new ProcessService(), isakovWorkingDir, isakovProcessPath, processArgs,
                    new SimpleFileService()),
                new QubitsToGroupsConverter<decimal>());
            return api;
        }

        public static IResponse<IBinaryGroup<decimal>> Run(decimal[] input)
        {
            if (input == null) return null;
            var groupsComparisonAPI = CreateGroupsComparisonAPI(new DemoMemoryConfiguration()); //This is the same thing as the Python script, but in the current's framework implementation.
            return groupsComparisonAPI.GetBestEqualGroups(input, ResultsFilters.GroupsLengthMustBeEqual);
        }
    }
}