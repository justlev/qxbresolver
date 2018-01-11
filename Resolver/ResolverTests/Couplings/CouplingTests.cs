using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Resolver.Coupling;
using Resolver.Models.Nodes;

namespace ResolverTests
{
    [TestClass]
    public class CouplingTests
    {
        [TestMethod]
        public void When_RequestingGraphCouplings_TheTraversersDistance_IsReturned()
        {
            var traverser = FakeContainer.GetTraverser<decimal>();
            var couplingProvider = new GraphTraversalCouplingProvider(traverser);

            var node1 = new Node<decimal>(1);
            var node2 = new Node<decimal>(2);

            traverser.GetLengthBetweenNodes(node1, node2).Returns(100);

            var result = couplingProvider.GetCoupling(node1, node2);

            traverser.Received(1).GetLengthBetweenNodes(node1, node2);
            Assert.AreEqual(100, result);
        }
    }
}