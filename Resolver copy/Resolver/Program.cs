using Resolver.Bias;
using Resolver.Convertion;
using Resolver.Coupling;
using Resolver.Facade;
using Resolver.Models.BinaryGroup;
using Resolver.QuantumResolving;
using Resolver.Services.Configuration;
using Resolver.Services.Files;
using Resolver.Services.Process;

namespace Resolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = CreateAPI(new DemoMemoryConfiguration());

            var testInput = new decimal[] {1, 4, 3, 9};
            var bestGroups = api.GetBestEqualGroups(testInput);
        }

        /// <summary>
        /// Creates an API.
        /// Can be a Rest API, can be a dll library published, can be any implementation.
        /// </summary>
        private static IQubitsCalculationAPI CreateAPI(IConfigurationProvider configuration)
        {
            var isakovProcessPath = configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_CONFIG_KEY);
            var isakovWorkingDir =
                configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_WORKING_DIRECTORY_CONFIG_KEY);
            var processArgs = configuration.GetValue(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_ARGS_CONFIG_KEY);

            var api = new QubitsCalculationAPI(new DecimalQuantumDataExtractionFacade(new SimpleCouplingProvider(), new DecimalBiasProvider()),
                new IsakovScriptQubitsResolver(new ProcessService(), isakovWorkingDir, isakovProcessPath, processArgs, new SimpleFileService()),
                new DecimalQubitsToGroupsConverter());
            return api;
        }
    }
}