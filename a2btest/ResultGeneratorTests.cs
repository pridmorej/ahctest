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
    public class ResultGeneratorTests
    {
        [Test]
        public void Generate_SimpleSearch_ReturnsShortestPath()
        {
            // Create the results.
            ResultPath expected = new ResultPath();
            expected.Push (new SearchNode(new Word("Spin")));
            expected.Push (new SearchNode(new Word("Spit")));
            expected.Push (new SearchNode(new Word("Spot")));
            
            Parameters p = new Parameters();
            Dictionary d = new Dictionary();

            p.StartWord = "Spin";
            p.EndWord = "Spot";
            p.ResultsFileName = "simpleresult.txt";

            Word sw = new Word(p.StartWord);
            Word ew = new Word(p.EndWord);

            d.Words.Add(new Word("Spit"));
            d.Words.Add(new Word("Spin"));
            d.Words.Add(new Word("Spat"));
            d.Words.Add(new Word("Spot"));
            d.Words.Add(new Word("Span"));

            SearchPreparer sp = new SearchPreparer(p, d);
            SearchStructure ss = sp.Prepare();
            ResultGenerator rg = new ResultGenerator(ss);
            ResultPath rp = rg.Generate();

            SearchNode e;
            SearchNode a;

            Assert.AreEqual(expected.Count, rp.Count);

            while (expected.Count > 0 && rp.Count > 0)
            {
                e = (SearchNode)expected.Pop();
                a = (SearchNode)rp.Pop();
                Assert.AreEqual(e.Word.Value, a.Word.Value);
            }
        }
    }
}
