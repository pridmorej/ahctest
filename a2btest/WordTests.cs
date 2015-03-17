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
        public void Set_ValueOfWord_IsCorrect()
        {
            string s = "hello";
            Word w = new Word(s);
            Assert.True(s.Equals(w.Value));
        }

        [Test]
        public void Read_LengthOfWord_IsCorrect()
        {
            string s = "hello";
            Word w = new Word(s);
            Assert.True(w.Length == s.Length);
        }

        [Test]
        public void Read_WordLetters_AreSameAsWord()
        {
            string s = "hello";
            Word w = new Word(s);
            Assert.True(s.Equals(String.Concat(w.Letters)));
        }

        [Test]
        public void Compare_TwoWordsWithOnlyOneLetterDifferent_AreIdentifiedCorrectly()
        {
            string a = "Spit";
            string b = "Spot";
            Word wa = new Word(a);
            Word wb = new Word(b);
            Assert.True(wa.IsOneLetterDifferentTo(wb));
        }

        [Test]
        public void Compare_TwoWordsWithMoreThanOneLetterDifferent_AreIdentifiedCorrectly()
        {
            string a = "Spit";
            string b = "Span";
            Word wa = new Word(a);
            Word wb = new Word(b);
            Assert.False(wa.IsOneLetterDifferentTo(wb));
        }
    }
}
