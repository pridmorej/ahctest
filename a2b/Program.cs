using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Controller c = ControllerFactory.GetInstance();
                c.Execute();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}
