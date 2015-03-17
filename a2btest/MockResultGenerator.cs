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
            rp.Push(new Word("Spit"));
            rp.Push(new Word("Spot"));
            rp.Push(new Word("Snot"));
            return rp;
        }
    }
}
