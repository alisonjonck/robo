using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

namespace WebApiTest.Services
{
    /// <summary>
    /// Camada de Serviços para testar a exposição dos estados de R.O.B.O. 
    /// </summary>
    [TestClass]
    public class RoboServiceTest
    {
        [TestMethod]
        public void TestRoboServiceGetRoboStates()
        {
            var roboService = new RoboService();

            Assert.IsNotNull(roboService);

            Assert.IsInstanceOfType(roboService, typeof(IRoboService));
        }
    }
}
