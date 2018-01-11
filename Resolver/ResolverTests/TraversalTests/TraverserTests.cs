using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resolver.Models.Nodes;
using Resolver.Services.Data;

namespace ResolverTests
{
    [TestClass]
    public class TraverserTests
    {
        private INodeTraverser<int> _sut;

        [TestMethod]
        public void When_RequestingDistance_BetweenElements_WithOneGap_InGraph_TheCorrectLength_IsReturned()
        {
            var expectedLength = 2;
            var node = new Node<int>(1);
            var childNode1 = new Node<int>(2);
            var childNode2 = new Node<int>(3);
            childNode1.AddConnection(childNode2);
            node.AddConnection(childNode1);
            
            _sut = new RecursiveNodeTraverser<int>(node);

            var result = _sut.GetLengthBetweenNodes(node, childNode2);
            
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void When_RequestingDistance_BetweenElements_FromDifferentSidesOfRootNode_TheCorrectLength_IsReturned()
        {
            var expectedLength = 3;
            var node = new Node<int>(1);
            var leftNode1 = new Node<int>(2);
            var leftNode2 = new Node<int>(3);
            leftNode1.AddConnection(leftNode2);
            node.AddConnection(leftNode1);

            var rightNode1 = new Node<int>(4);
            node.AddConnection(rightNode1);
            
            _sut = new RecursiveNodeTraverser<int>(node);

            var result = _sut.GetLengthBetweenNodes(rightNode1, leftNode2);
            
            Assert.AreEqual(3, result);
        }
        
        [TestMethod]
        public void When_RequestingDistance_BetweenNotConnectedElements_MinusOneIsReturned()
        {
            var expectedLength = 3;
            var node = new Node<int>(1);
            var node2 = new Node<int>(2);
            
            _sut = new RecursiveNodeTraverser<int>(node);

            var result = _sut.GetLengthBetweenNodes(node, node2);
            
            Assert.AreEqual(-1, result);
        }
    }
}