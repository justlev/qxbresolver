using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resolver.Convertion;
using Resolver.Models.BinaryGroup;

namespace ResolverTests.Conversion
{
    [TestClass]
    public class QubitsToGroupsConverterTests
    {
        private int[] _originalInput;
        private IQubitsToGroupsConverter<int> _converter;
        private List<List<short>> _qubitsGroups;

        private void SetUp()
        {
            _converter = new QubitsToGroupsConverter<int>();
            _originalInput = new int[] {1, 2, 3, 4};
            _qubitsGroups = new List<List<short>>();
            _qubitsGroups.Add(new List<short>() { 1, -1, 1, -1});
        }
        
        [TestMethod]
        public void When_ConvertingQubits_To_Groups_TheCorrectGroups_AreReturned()
        {
            SetUp();
            var result = _converter.DivideInputIntoGroupsByQubits(_originalInput, _qubitsGroups);
            
            DefaultAssertion(result);
        }

        [TestMethod]
        public void When_MultipleQubitSquences_AreEntered_TheAmountOfGroupsReturned_Matches_MaxCountParameter()
        {
            SetUp();
            _qubitsGroups.Add(new List<short>{1,1,1,1});

            var result = _converter.DivideInputIntoGroupsByQubits(_originalInput, _qubitsGroups, 1);
            
            DefaultAssertion(result);
        }
        
        [TestMethod]
        public void When_MultipleQubitSquences_AreEntered_AndFilter_IsSend_TheResults_AreAppropriately_Filtered()
        {
            SetUp();
            _qubitsGroups.Add(new List<short>{1,1,1,1});

            var result = _converter.DivideInputIntoGroupsByQubits(_originalInput, _qubitsGroups, 1, qubits => false);
            
            Assert.AreEqual(0, result.Count());
        }

        private void DefaultAssertion(IEnumerable<IBinaryGroup<int>> result)
        {
            Assert.AreEqual(1, result.Count());
            var group = result.First();
            Assert.IsTrue(group.Group1.Contains(1));
            Assert.IsTrue(group.Group1.Contains(3));
            
            Assert.IsTrue(group.Group2.Contains(2));
            Assert.IsTrue(group.Group2.Contains(4));
        }
        
    }
}