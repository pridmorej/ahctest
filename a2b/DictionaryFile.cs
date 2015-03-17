using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class DictionaryFile
    {
        public string Name { get; set; }
        public DictionaryReader DictionaryReader { get; set; }
        public int WordLengthFilter { get; set; }
    }
}
