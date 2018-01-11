using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Resolver.Facade;

namespace ResolverTests.Facade
{
    [TestClass]
    public class DataExtractionFacadeTests
    {
        [TestMethod]
        public void When_Requesting_DataExtraction_BothCouplesAndBiases_Are_Extracted()
        {
            var couplingProvider = FakeContainer.GetCouplingProvider<int, int>();
            var biasProvider = FakeContainer.GetBiasProvider<int, int>();
            var facade = new QuantumDataExtractionFacade<int, int, int>(couplingProvider, biasProvider);
            var input = new int[] {1, 2};

            var result = facade.GetCouplingsAndBiases(input);
            
            Received.InOrder(() =>
            {
                biasProvider.GetBias(1,1);
                couplingProvider.GetCoupling(1, 2);
                biasProvider.GetBias(2, 2);
            });
        }
    }
}