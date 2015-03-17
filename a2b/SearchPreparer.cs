using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class SearchPreparer : ISearchPreparer
    {
        private Dictionary _d;
        private Parameters _p;

        public SearchPreparer(Parameters p, Dictionary d)
        {
            _d = d;
            _p = p;
        }

        public SearchStructure Prepare()
        {
            SearchStructure s = new SearchStructure(_d.Words);

            // Now need to do the expensive bit of linking all the words which are only one letter different.
            // Unfortunately, I don't know of a more efficient way of doing this other than n(2).
            foreach (SearchNode n1 in s.SearchNodes)
            {
                foreach (SearchNode n2 in s.SearchNodes)
                {
                    // Perform a reference comparison to make sure not wasting time comparing the same SearchNode.
                    if (!n1.Equals(n2) && n1.Word.IsOneLetterDifferentTo(n2.Word))
                    {
                        s.AddLink(n1, n2);
                    }
                }
            }

            return s;
        }
    }
}
