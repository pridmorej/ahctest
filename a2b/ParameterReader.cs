using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class ParameterReader
    {
        public Parameters Read(string[] args, Parameters p)
        {
            if (args.Length != 5) { throw new ArgumentException("Invalid list of arguments provided."); }

            p.DictionaryFileName = args[1];
            p.StartWord = args[2];
            p.EndWord = args[3];
            p.ResultsFileName = args[4];

            return p;
        }
    }
}
