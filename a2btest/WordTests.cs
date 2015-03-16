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
    public class WordTests
    {
        [Test]
        public void Test_ValueOfWord_IsCorrect()
        {
            string s = "hello";
            Word w = new Word(s);
            Assert.That(w.Value == s);
        }

        [Test]
        public void Test_LengthOfWord_IsCorrect()
        {
            string s = "hello";
            Word w = new Word(s);
            Assert.That(w.Length == s.Length);
        }

        [Test]
        public void Test_SortedWordLetters_AreInCorrectOrder()
        {
            string s = "hello";
            string t = "ehllo";
            Word w = new Word(s);
            Assert.That(w.Letters.ToString() == t);
        }
    }
}
