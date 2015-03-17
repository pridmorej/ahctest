using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class ResultPath : Stack
    {
        /// <summary>
        /// Converts the stack of results to a string with each result on a new line.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Use stringbuilder as more efficient than concatenating strings.
            StringBuilder results = new StringBuilder();
            results.EnsureCapacity(this.Count);

            // Need to add results in reverse order as this is a stack.
            foreach (string result in this)
            {
                results.Insert(0, result + Environment.NewLine);
            }

            return results.ToString();
        }
    }
}
