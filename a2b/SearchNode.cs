using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class SearchNode
    {
        public SearchNode(Word word)
        {
            this.Word = word;
            this.Words = new Words();
        }
        public Word Word { get; set; }
        public bool Visited { get; set; }
        public Words Words { get; set; }
    }
}
