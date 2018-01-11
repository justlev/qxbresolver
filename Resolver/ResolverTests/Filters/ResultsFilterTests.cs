using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resolver.Filters;

namespace ResolverTests.Filters
{
    [TestClass]
    public class ResultsFilterTests
    {
        [TestMethod]
        public void EqualGroupsLength_ResultFilter_ActuallyFilters_Correctly_WhenListMatchesFilter()
        {
            var input = new List<short> {1, -1, 1, -1};
            var result = ResultsFilters.GroupsLengthMustBeEqual(input);
             
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void EqualGroupsLength_ResultFilter_ActuallyFilters_Correctly_WhenListDoesNotMatchesFilter()
        {
            var input = new List<short> {1, -1, 1, 1};
            var result = ResultsFilters.GroupsLengthMustBeEqual(input);
             
            Assert.IsFalse(result);
        }
    }
}