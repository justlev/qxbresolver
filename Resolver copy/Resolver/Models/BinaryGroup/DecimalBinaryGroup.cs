using System.Collections.Generic;

namespace Resolver.Models.BinaryGroup
{
    public class DecimalBinaryGroup : IBinaryGroup<decimal>
    {
        private IList<decimal> _group1;
        private IList<decimal> _group2;

        public DecimalBinaryGroup()
        {
            _group1 = new List<decimal>();
            _group2 = new List<decimal>();
        }
        
        public IEnumerable<decimal> Group1
        {
            get { return _group1; }
        }
        
        public IEnumerable<decimal> Group2
        {
            get { return _group2; }
        }
        
        public void AddToGroup1(decimal value)
        {
            _group1.Add(value);
        }

        public void AddToGroup2(decimal value)
        {
            _group2.Add(value);
        }
    }
}