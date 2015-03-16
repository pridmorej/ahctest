using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class Dictionary
    {
        public Dictionary(DictionaryReader dictionaryReader)
        {
            _dictionaryReader = dictionaryReader;
        }
        private DictionaryReader _dictionaryReader;
        public Words Words { get; private set; }
    }
}
