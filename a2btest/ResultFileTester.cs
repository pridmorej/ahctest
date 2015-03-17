using a2b;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2btest
{
    [TestFixture]
    public class ResultFileTester
    {
        [Test]
        public void SetGetProperty_Name_IsValid()
        {
            ResultFile rf = new ResultFile();
            string n = "results.txt";

            rf.Name = n;

            Assert.AreEqual(n, rf.Name);
        }
    }
}
