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
        public void Create_NewController_IsNotNull()
        {
            Controller controller = ControllerFactory.GetInstance();
            Assert.IsNotNull(controller);
            Assert.IsInstanceOf<Controller>(controller);
        }
        public void Create_NewController_IsInstanceOfController()
        {
            Controller controller = ControllerFactory.GetInstance();
            Assert.IsInstanceOf<Controller>(controller);
        }
    }
}
