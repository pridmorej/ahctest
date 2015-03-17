using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class SearchNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="word"></param>
        public SearchNode(Word word)
        {
            this.Distance = 0;
            this.Word = word;
            this.Neighbours = new List<SearchNode>();
        }

        /// <summary>
        /// The word as this Node
        /// </summary>
        public Word Word { get; protected set; }

        /// <summary>
        /// Has this Node been visited during a search?
        /// </summary>
        public bool Visited { get; set; }

        /// <summary>
        /// Distance from the start of the search (only set when visited).
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// A list of linked SearchNodes.
        /// </summary>
        public List<SearchNode> Neighbours { get; set; }

        /// <summary>
        /// A link back to the previous search node when following a path.
        /// </summary>
        public SearchNode Previous { get; set; }
    }
}
