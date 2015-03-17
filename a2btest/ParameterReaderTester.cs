using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a2b;
using NUnit.Framework;

namespace a2btest
{
    [TestFixture]
    public class ParameterReaderTester
    {
        [Test]
        public void Read_ValidCommandLineArgs_PopulateParameters()
        {
            string[] args = new string[5] { "a2b.exe", "words-english.txt", "Start", "End", "results.txt" };

            ParameterReader pr = new ParameterReader(args);
            Parameters p = pr.GetParameters();

            Assert.That(p.DictionaryFileName == args[1]);
            Assert.That(p.StartWord == args[2]);
            Assert.That(p.EndWord == args[3]);
            Assert.That(p.ResultsFileName == args[4]);
        }
    }
}
