using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class CaseSentitveComparer : IComparer<String>
    {
        public int Compare(string x, string y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return string.Compare(x.ToLower() , y.ToLower()); ;
        }
    }
}
