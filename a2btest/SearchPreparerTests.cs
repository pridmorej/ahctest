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
    public class SearchPreparerTests
    {
        [Test]
        public void Add_TwoWordsOneLetterDifferent_AreLinkedTogether()
        {
            Parameters p = new Parameters();
            Dictionary d = new Dictionary();

            p.StartWord = "aaaaa";
            p.EndWord = "aabaa";        // Only one letter different.

            Word sw = new Word(p.StartWord);
            Word ew = new Word(p.EndWord);

            d.Words.Add(sw);
            d.Words.Add(ew);

            SearchPreparer sp = new SearchPreparer(p, d);
            SearchStructure ss = sp.Prepare();

            // Test that both nodes have been added.
            Assert.AreEqual(ss.SearchNodes.Count, 2);

            // Test that both nodes point to each other.
            CollectionAssert.Contains(ss.SearchNodes[0].Neighbours, ss.SearchNodes[1]);
            CollectionAssert.Contains(ss.SearchNodes[1].Neighbours, ss.SearchNodes[0]);
        }

        [Test]
        public void Add_TwoWordsMoreThanOneLetterDifferent_AreNotLinkedTogether()
        {
            Parameters p = new Parameters();
            Dictionary d = new Dictionary();

            p.StartWord = "aaaaa";
            p.EndWord = "abaca";      // Two letters are different.

            Word sw = new Word(p.StartWord);
            Word ew = new Word(p.EndWord);

            d.Words.Add(sw);
            d.Words.Add(ew);

            SearchPreparer sp = new SearchPreparer(p, d);
            SearchStructure ss = sp.Prepare();

            // Test that both nodes have been added.
            Assert.AreEqual(ss.SearchNodes.Count, 2);

            // Test that both nodes do not point to each other.
            CollectionAssert.DoesNotContain(ss.SearchNodes[0].Neighbours, ss.SearchNodes[1]);
            CollectionAssert.DoesNotContain(ss.SearchNodes[1].Neighbours, ss.SearchNodes[0]);
        }
    }
}
