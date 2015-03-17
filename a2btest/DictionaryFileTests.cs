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
    public class DictionaryFileTests
    {
        [Test]
        public void SetGetProperty_FileName_IsCorrect()
        {
            DictionaryFile d = new DictionaryFile();
            string s = "dictionary.txt";

            d.Name = s;

            Assert.AreEqual(s, d.Name);
        }

        [Test]
        public void SetGetProperty_WordLengthFilter_IsCorrect()
        {
            DictionaryFile d = new DictionaryFile();
            int i = 10;

            d.WordLengthFilter = i;

            Assert.AreEqual(i, d.WordLengthFilter);
        }

        [Test]
        public void SetGetProperty_DictionaryReader_IsCorrect()
        {
            DictionaryFile d = new DictionaryFile();
            DictionaryReader dr = new DictionaryReader();

            d.DictionaryReader = dr;

            Assert.AreSame(dr, d.DictionaryReader);
        }
    }
}
