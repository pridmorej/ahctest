using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    /// <summary>
    /// Represents a word from the Dictionary (lower case)
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
        public string Value { get; protected set; }

        /// <summary>
        /// The length of the word.
        /// </summary>
        public int Length { get { return this.Value.Length; } }

        /// <summary>
        /// An array of letters (used when determining how may letters are different).
        /// </summary>
        /// <remarks>
        /// The word is converted to lower case in order to make the character comparison case-insensitive.
        /// </remarks>
        public char[] Letters
        {
            get
            {
                return this.Value.ToLower().ToArray();
            }
        }

        /// <summary>
        /// Tests whether a word is one letter different to the given word.
        /// </summary>
        /// <remarks>
        /// Jumps out of the comparison as soon as more than one character difference has been found.
        /// In terms of this particular test, duplicates are removed, so the cases of full length comparisons being made will be minimal.
        /// </remarks>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool IsOneLetterDifferentTo(Word word)
        {
            char[] a = this.Letters;
            char[] b = word.Letters;
            int c = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (!a[i].Equals(b[i])) { c++; }
                if (c > 1) { return false; }
            }
            return c == 1;
        }
    }
}
