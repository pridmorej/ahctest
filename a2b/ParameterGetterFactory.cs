using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    /// <summary>
    /// Returns a ParameterGetter depending upon whether args were passed to the command line or not.
    /// </summary>
    public static class ParameterGetterFactory
    {
        public static IParameterGetter GetInstance()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args != null && args.Length > 1)
            {
                return new ParameterReader(args);
            }
            else
            {
                return new ParameterPrompter(Console.Out, Console.In);
            }
        }
    }
}
