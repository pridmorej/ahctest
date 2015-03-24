using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public interface IController
    {
        void Execute(string DictionaryFileName, string StartWord, string EndWord, string ResultsFileName);
    }
}
