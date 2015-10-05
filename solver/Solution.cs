using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeOne.Solver
{
    class Solution
    {
        List<int> values;
        int lastValueChangedIndex;

        public Solution(List<int> values, int lastValueChangedIndex)
        {
            this.values = values;
            this.lastValueChangedIndex = lastValueChangedIndex;
        }

        public List<int> getValues() { return values; }

        public int getLastValueChangedIndex() { return lastValueChangedIndex; }
    }
}
