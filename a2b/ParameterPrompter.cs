using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class ParameterPrompter
    {
        public Parameters Prompt(StreamWriter output, StreamReader input, Parameters p)
        {
            if (output == null) { throw new ArgumentNullException("output stream cannot be null."); }
            if (input == null) { throw new ArgumentNullException("input stream cannot be null."); }
            if (p == null) { throw new ArgumentNullException("parameters cannot be null."); }

            output.WriteLine("Enter the name of the Dictionary file: ");
            p.DictionaryFileName = input.ReadLine();

            output.WriteLine("Enter the Start Word: ");
            p.StartWord = input.ReadLine();

            output.WriteLine("Enter the End Word: ");
            p.EndWord = input.ReadLine();

            output.WriteLine("Enter the name of the Results file: ");
            p.ResultsFileName = input.ReadLine();

            return p;
        }
    }
}
