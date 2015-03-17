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
    public class WordsTests
    {
        [Test]
        public void Add_OneOrMoreWordsToTheList_IsContainedInTheList()
        {
            Words words = new Words();

            Word a = new Word("hello");
            Word b = new Word("goodbye");

            words.Add(a);
            words.Add(b);

            Assert.Contains(a, words);
            Assert.Contains(b, words);

            Assert.That(words.Count == 2);
        }


    }
}
