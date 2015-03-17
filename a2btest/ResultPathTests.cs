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
        public void Push_ItemOnToResultPath_AddsItemToStack()
        {
            ResultPath rp = new ResultPath();
            string a = "a";

            rp.Push(a); // NOTE: Boxing string to reference type.

            CollectionAssert.Contains(rp, a);
        }

        [Test]
        public void Pop_ItemOffOfResultPath_RemovesItemFromStack()
        {
            ResultPath rp = new ResultPath();
            string a = "a";

            rp.Push(a); // NOTE: Boxing string value type to reference type.

            a = (string)rp.Pop();  // NOTE: Unboxing reference type to string value type.

            CollectionAssert.DoesNotContain(rp, a);
        }
    }
}
