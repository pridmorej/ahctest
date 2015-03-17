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

        public SearchStructure(Words words)
        {
            this.SearchNodes = new List<SearchNode>();
            foreach (Word word in words)
            {
                this.SearchNodes.Add(new SearchNode(word));
            }
        }

        public void AddLink(SearchNode from, SearchNode to)
        {
            from.Neighbours.Add(to);
            to.Neighbours.Add(from);
        }
    }
}
