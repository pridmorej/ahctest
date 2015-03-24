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
    public class ResultPathTests
    {
        [Test]
        public void Add_ItemOnToResultPath_AddsItemToList()
        {
            ResultPath rp = new ResultPath();
            SearchNode a = new SearchNode(new Word("a"));

            rp.Add(a);

            CollectionAssert.Contains(rp, a);
        }

        [Test]
        public void Remove_ItemOffOfResultPath_RemovesItemFromList()
        {
            ResultPath rp = new ResultPath();
            SearchNode a = new SearchNode(new Word("a"));

            rp.Add(a);
            rp.Remove(a);

            CollectionAssert.DoesNotContain(rp, a);
        }
    }
}
