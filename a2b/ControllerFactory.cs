using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public static class ControllerFactory
    {
        public static IController GetInstance()
        {
            return new Controller();
        }
    }
}
