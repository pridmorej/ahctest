using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    /// <summary>
    /// Holds information about where the results should be written.
    /// </summary>
    public class ResultFile
    {
        public string Name { get; set; }
        public ResultWriter ResultWriter { get; set; }
    }
}
