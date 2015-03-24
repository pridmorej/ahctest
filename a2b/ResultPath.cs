using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class ResultPath : List<SearchNode>
    {
        /// <summary>
        /// Converts the list of results to a string with each result on a new line.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Use stringbuilder as more efficient than concatenating strings.
            StringBuilder results = new StringBuilder();
            results.EnsureCapacity(this.Count);
            foreach (SearchNode result in this)
            {
                results.AppendLine(result.Word.Value);
            }
            return results.ToString();
        }
    }
}
