using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using a2b;
using NUnit.Framework;

namespace a2btest
{
    [TestFixture]
    public class ParametersTests
    {
        [Test]
        public void Set_Properties_AreCorrect()
        {
            Parameters p = new Parameters();

            string dictionaryFileName = "dictionary.txt";
            string startWord = "startword";
            string endWord = "endword";
            string resultsFileName = "results.txt";

            p.DictionaryFileName = dictionaryFileName;
            p.StartWord = startWord;
            p.EndWord = endWord;
            p.ResultsFileName = resultsFileName;

            Assert.AreEqual(dictionaryFileName, p.DictionaryFileName);
            Assert.AreEqual(startWord, p.StartWord);
            Assert.AreEqual(endWord, p.EndWord);
            Assert.AreEqual(resultsFileName, p.ResultsFileName);

        }
    }
}
