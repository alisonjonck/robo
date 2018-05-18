using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiTest
{
    [TestClass]
    public class RoboTest
    {
        [TestMethod]
        public void TestRoboExists()
        {
            var robo = new Robo();

            Assert.IsNotNull(robo);
        }


    }
}
