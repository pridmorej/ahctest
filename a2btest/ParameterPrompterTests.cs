using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a2b;
using Moq;
using NUnit.Framework;
using System.IO;

namespace a2btest
{
    [TestFixture]
    public class ParameterPrompterTester
    {
        [Test]
        public void Read_InputStream_ParametersArePopulated()
        {
            string[] lines = new string[5] { "words-english.txt", 
                                             "Start", 
                                             "End", 
                                             "results.txt",
                                             "" };

            TextWriter output = new StringWriter(); // Fake Console.Out;

            // Add environment.newline to mimic user pressing return.
            TextReader input = new StringReader(String.Join(Environment.NewLine, lines)); // Fake Console.In;

            ParameterPrompter pr = new ParameterPrompter(output, input);
            
            Parameters p = pr.GetParameters();

            Assert.That(String.Compare(p.DictionaryFileName, lines[0]) == 0);
            Assert.That(String.Compare(p.StartWord, lines[1]) == 0);
            Assert.That(String.Compare(p.EndWord, lines[2]) == 0);
            Assert.That(String.Compare(p.ResultsFileName, lines[3]) == 0);
        }
    }

}
