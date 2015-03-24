using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using a2b;
using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace a2btest
{
    [TestFixture]
    public class ResultWriterTests
    {
        [Test]
        public void Writing_ResultPathToResultFile_IsValid()
        {
            // Create the results.
            string[] results = new string[4] { "a", 
                                               "b", 
                                               "c", 
                                               "d" };
            string fileName = "fake.txt";

            // Load the results
            ResultPath rp = new ResultPath();
            foreach (string result in results)
            {
                rp.Add(new SearchNode(new Word(result)));
            }

            // Write the results.
            ResultFile rf = new ResultFile();
            rf.Name = fileName;

            ResultWriter rw = new ResultWriter(rf, rp);
            rw.Write();

            // Read the written results.
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            string[] actual = File.ReadAllLines(path);

            // Validate.
            CollectionAssert.AreEqual(actual, results);
        }
    }
}
