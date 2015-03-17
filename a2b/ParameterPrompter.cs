using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class ParameterPrompter : IParameterGetter
    {

        private TextWriter _output;
        private TextReader _input;

        public ParameterPrompter(TextWriter output, TextReader input)
        {
            _output = output;
            _input = input;
        }

        public Parameters GetParameters()
        {
            Parameters p = new Parameters();

            if (_output == null) { throw new ArgumentNullException("output stream cannot be null."); }
            if (_input == null) { throw new ArgumentNullException("input stream cannot be null."); }

            if (p == null) { throw new ArgumentNullException("parameters cannot be null."); }

            _output.WriteLine("Enter the name of the Dictionary file: ");
            p.DictionaryFileName = _input.ReadLine();

            _output.WriteLine("Enter the Start Word: ");
            p.StartWord = _input.ReadLine();

            _output.WriteLine("Enter the End Word: ");
            p.EndWord = _input.ReadLine();

            _output.WriteLine("Enter the name of the Results file: ");
            p.ResultsFileName = _input.ReadLine();

            return p;
        }
    }
}
