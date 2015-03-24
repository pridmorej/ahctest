using a2b;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2btest
{
    public class MockResultGenerator : IResultGenerator
    {
        public ResultPath Generate()
        {
            ResultPath rp = new ResultPath();
            rp.Add(new SearchNode(new Word("Spit")));
            rp.Add(new SearchNode(new Word("Spot")));
            rp.Add(new SearchNode(new Word("Snot")));
            return rp;
        }
    }
}
