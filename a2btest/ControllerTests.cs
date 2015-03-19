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
    public class ControllerTests
    {
        /// <summary>
        /// 1.1.a	Test: Create an object responsible for controlling the process.
        /// </summary>
        public void Create_NewController_IsNotNull()
        {
            IController controller = ControllerFactory.GetInstance();
            Assert.IsNotNull(controller);
            Assert.IsInstanceOf<Controller>(controller);
        }

        /// <summary>
        /// 1.1.b	Test: Create an object responsible for controlling the process.
        /// </summary>
        public void Create_NewController_IsInstanceOfController()
        {
            IController controller = ControllerFactory.GetInstance();
            Assert.IsInstanceOf<Controller>(controller);
        }
    }
}
