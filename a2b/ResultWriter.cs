using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    /// <summary>
    /// Responsible for writing the results.
    /// </summary>
    public class ResultWriter : IResultWriter
    {
        private ResultFile _file;
        private ResultPath _rp;
 
        public ResultWriter(ResultFile file, ResultPath rp)
        {
            _file = file;
            _rp = rp;
        }

        public void Write()
        {
            // The file is going to be written to the current executing directory.
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _file.Name);

            // Create or Open a file for writing.
            using (StreamWriter sw = File.CreateText(path))
            {
                // Write the ResultPath to the file.
                sw.Write(_rp.ToString());
                sw.Flush();
                sw.Close();
            } // Calls Dispose.
        }
    }
}
