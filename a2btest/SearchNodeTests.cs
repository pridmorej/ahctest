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
    public class SearchNodeTests
    {
        [Test]
        public void Create_SearchNode_IsValid()
        {
            string s = "hello";
            Word w = new Word(s);
         
            SearchNode sn = new SearchNode(w);

            Assert.AreSame(sn.Word, w);
            Assert.AreEqual(sn.Word.Value, s);
        }

        [Test]
        public void SetGetProperty_Visited_IsCorrect()
        {
            string s = "hello";
            Word w = new Word(s);
            SearchNode sn = new SearchNode(w);

            sn.Visited = true;

            Assert.True(sn.Visited);
        }

        [Test]
        public void SetGetProperty_Neighbours_IsCorrect()
        {
            string sa = "hello";
            string sb = "back";
            Word wa = new Word(sa);
            Word wb = new Word(sb);
            SearchNode sna = new SearchNode(wa);
            SearchNode snb = new SearchNode(wb);

            sna.Neighbours.Add(snb);

            CollectionAssert.Contains(sna.Neighbours, snb);
            Assert.AreSame(sna.Neighbours[0], snb);
            Assert.AreSame(sna.Neighbours[0].Word, snb.Word);
            Assert.AreEqual(sna.Neighbours[0].Word.Value, sb);
        }
    }
}
