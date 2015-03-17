using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class SearchStructure
    {
        public List<SearchNode> SearchNodes { get; protected set; }

        public SearchNode StartNode;
        public SearchNode EndNode;

        public SearchStructure(Words words, Parameters p)
        {
            this.SearchNodes = new List<SearchNode>();
            foreach (Word word in words)
            {
                SearchNode sn = new SearchNode(word);
                this.SearchNodes.Add(sn);

                // Set references to the StartWord and EndWord as they are loaded.
                // NOTE: I would probably raise an event here to notify the caller that a node was added, so that the Parameters don't have to be passed in here.
                if (word.Value.Equals(p.StartWord))
                {
                    this.StartNode = sn;
                }
                if (word.Value.Equals(p.EndWord))
                {
                    this.EndNode = sn;
                }
            }
        }

        public void AddLink(SearchNode from, SearchNode to)
        {
            from.Neighbours.Add(to);
            to.Neighbours.Add(from);
        }
    }
}
