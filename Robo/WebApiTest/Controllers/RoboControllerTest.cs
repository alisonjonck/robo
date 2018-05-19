using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;
using WebApi.Controllers;

namespace WebApiTest.Controllers
{
    [TestClass]
    public class RoboControllerTest
    {
        [TestMethod]
        public void TestRoboControllerReturnsRobo()
        {
            var controller = new RoboController();
            Assert.IsNotNull(controller);

            var robo = controller.Get();
            Assert.IsNotNull(robo);

            Assert.IsInstanceOfType(robo, typeof(RoboViewModel));
        }

        [TestMethod]
        public void TestRoboReturnedHasItsArms()
        {
            var controller = new RoboController();
            Assert.IsNotNull(controller);

            var robo = controller.Get();
            Assert.IsNotNull(robo);

            Assert.IsInstanceOfType(robo, typeof(RoboViewModel));

            Assert.IsNotNull(robo.BracoDireito);
            Assert.IsNotNull(robo.BracoEsquerdo);
        }
    }
}
