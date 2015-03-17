using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public class DictionaryReader : IDictionaryReader
    {
        public Dictionary Read(DictionaryFile file)
        {
            // Locate the file and check that it exists.
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), file.Name);
            if (!File.Exists(path)) { throw new FileNotFoundException("Could not locate dictionary file '" + path + "'."); }

            // Load contents and filter by the required word length.
            string fileContents = File.ReadAllText(path);
            IEnumerable<string> lines = fileContents.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length == file.WordLengthFilter);

            // Populate the dictionary with all words of the required length.
            Dictionary d = new Dictionary();
            foreach (string line in lines)
            {
                d.Words.Add(new Word(line));
            }

            return d;
        }
    }
}
