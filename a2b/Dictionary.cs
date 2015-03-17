using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    /// <summary>
    /// 
    /// </summary>
    public class Dictionary
    {
        // TODO: The Dictionary class is now superfluous.  I can just represent the dictionary with the Words class.  Therefore need to factor out use of this Dictionary class.
        public Dictionary()
        {
            this.Words = new Words();
        }

        public Words Words { get; protected set; }
    }
}
