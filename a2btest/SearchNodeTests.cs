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
        public void SetGetProperty_BackWord_IsCorrect()
        {
            string s = "hello";
            string t = "back";
            Word w = new Word(s);
            Word b = new Word(t);
            SearchNode sn = new SearchNode(w);

            sn.BackWord = b;

            Assert.AreSame(sn.BackWord, b);
            Assert.AreEqual(sn.BackWord.Value, t);
        }
    }
}
