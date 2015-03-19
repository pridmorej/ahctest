using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    /*
     * See "test.bat" for sample args.
     * 
     * arg[0] = "a2b.exe"
     * arg[1] = "<dictionaryfile.txt>"
     * arg[2] = "<StartWord>"
     * arg[3] = "<EndWord>"
     * arg[4] = "<resultfile.txt>"
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IController c = ControllerFactory.GetInstance();
                c.Execute();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
