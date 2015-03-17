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
            this.Word = word;
            this.NextWords = new Words();
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
        /// A list of related words.
        /// </summary>
        public Words NextWords { get; set; }

        /// <summary>
        /// The previous word.
        /// </summary>
        public Word BackWord { get; set; }
    }
}
