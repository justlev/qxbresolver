using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Resolver.CouplingAndBias;
using Resolver.Models.BinaryGroup;
using Resolver.Models.Resolving;

namespace ResolverTests.ApiTests
{
    [TestClass]
    public class ResolverApiIntegrationTests
    {
        [TestMethod]
        public void When_Requesting_SimpleAPI_ToResolve_AllAppropriateActors_AreInvoked()
        {
            var facade = FakeContainer.GetFacade<int, int, int, int>();
            var converter = FakeContainer.GetQubitsToGroupsConverter<int>();
            var resolver = FakeContainer.GetResolvver<int, int, int, int>();
            var api = new QubitsCalculationAPI<int, int, int, int>(facade, resolver, converter);
            var input = new[] {1, 2, 3, 4};
            var couplingsAndBiases = new CouplingsAndBiases<int, int, int>();
            couplingsAndBiases.AddBias(0,0);
            couplingsAndBiases.AddCoupling(0,0,0);
            facade.GetCouplingsAndBiases(input).Returns(couplingsAndBiases);
            var resolveResponse = new List<IQubitsResolvingResponse>();
            var sortedQubitsList = new List<short>();
            resolveResponse.Add(new IsakovScriptResponse(1, sortedQubitsList, 1));
            resolver.Resolve(input, couplingsAndBiases.Biases, couplingsAndBiases.Couplings).Returns(resolveResponse);
            
            api.GetResolvedGroups(input);

            Received.InOrder(() =>
            {
                facade.GetCouplingsAndBiases(input);
                resolver.Resolve(input, couplingsAndBiases.Biases, couplingsAndBiases.Couplings);
                converter.DivideInputIntoGroupsByQubits(input, Arg.Is<IEnumerable<IEnumerable<short>>>(arg =>
                    arg.Count() == 1 && arg.First().Equals(sortedQubitsList)));
            });
        }
    }
}