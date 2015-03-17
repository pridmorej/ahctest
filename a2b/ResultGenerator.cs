using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class ResultGenerator : IResultGenerator
    {
        private SearchStructure _ss;

        public ResultGenerator(SearchStructure searchStructure)
        {
            _ss = searchStructure;
        }

        public ResultPath Generate()
        {
            ResultPath rp = new ResultPath();

            // TODO: Need to now perform the actual search.

            return rp;
        }
    }
}
