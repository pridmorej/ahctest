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

            Assert.That(p.DictionaryFileName.Equals(lines[0]));
            Assert.That(p.StartWord.Equals(lines[1]));
            Assert.That(p.EndWord.Equals(lines[2]));
            Assert.That(p.ResultsFileName.Equals(lines[3]));
        }
    }

}
