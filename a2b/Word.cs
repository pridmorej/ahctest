using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    /// <summary>
    /// Represents a word from the Dictionary
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public Word(string value) { this.Value = value; }

        /// <summary>
        /// The actual word.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The length of the word.
        /// </summary>
        public int Length { get { return this.Value.Length; } }

        /// <summary>
        /// A sorted array of letters (used when determining how may letters are different).
        /// </summary>
        public char[] Letters { get { return String.Concat(this.Value.OrderBy(c => c)).ToCharArray(); } }
    }
}
