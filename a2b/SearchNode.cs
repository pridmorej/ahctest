using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class SearchNode : IComparable<SearchNode>
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
        /// Calculates the distance from this searchnode to the startnode. 
        /// </summary>
        /// <param name="startNode"></param>
        /// <returns></returns>
        public int DistanceFrom(SearchNode startNode)
        {
            SearchNode n = this;
            int d = 0;
            while (!n.Equals(startNode))
            {
                n = n.Previous;
                d++;
            }
            return d;
        }

        /// <summary>
        /// Implements IComparable for use in the PriorityQueue.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(SearchNode obj)
        {
            if (obj == null)
                throw new InvalidCastException();
            if (this.Distance > obj.Distance)
                return 1;
            if (this.Distance == obj.Distance)
                return 0;
            return -1;
        }
        
        /// <summary>
        /// A list of linked SearchNodes.
        /// </summary>
        public List<SearchNode> Neighbours { get; set; }

        /// <summary>
        /// A link back to the previous search node when following a path.
        /// </summary>
        public SearchNode Previous { get; set; }

        /// <summary>
        /// Displays details about the SearchNode.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Join(", ", new string[] { this.Word.Value, "D: " + this.Distance.ToString(), "N: " + this.Neighbours.Count.ToString() });
        }


    }
}
