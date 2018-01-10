using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Resolver.Models.BinaryGroup
{
    public class BinaryGroup<TInput> : IBinaryGroup<TInput>
    {
        private IList<TInput> _group1;
        private IList<TInput> _group2;

        public BinaryGroup()
        {
            _group1 = new List<TInput>();
            _group2 = new List<TInput>();
        }
        
        public IEnumerable<TInput> Group1
        {
            get { return _group1; }
        }
        
        public IEnumerable<TInput> Group2
        {
            get { return _group2; }
        }
        
        public void AddToGroup1(TInput value)
        {
            _group1.Add(value);
        }

        public void AddToGroup2(TInput value)
        {
            _group2.Add(value);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(GetGroupString("Group 1", Group1));
            sb.Append(Environment.NewLine);
            sb.Append(GetGroupString("Group 2", Group2));
            return sb.ToString();
        }

        private string GetGroupString(string groupName, IEnumerable<TInput> group)
        {
            var sb = new StringBuilder();
            sb.Append(groupName);
            sb.Append(": [");
            foreach (var item in group)
            {
                sb.Append(item);
                sb.Append("  ");
            }
            sb.Append("]\n");
            return sb.ToString();
        }
    }
}