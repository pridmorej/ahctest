using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class ParameterReader : IParameterGetter
    {
        private string[] _args;

        public ParameterReader(string[] args)
        {
            _args = args;
        }

        public Parameters GetParameters()
        {
            if (_args.Length != 5) { throw new ArgumentException("Invalid list of arguments provided."); }

            Parameters p = new Parameters();

            p.DictionaryFileName = _args[1];
            p.StartWord = _args[2];
            p.EndWord = _args[3];
            p.ResultsFileName = _args[4];

            return p;
        }
    }
}
