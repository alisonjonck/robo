using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;
using WebApi.Controllers;

namespace WebApiTest.Controllers
{
    [TestClass]
    public class RoboControllerTest
    {
        private RoboController _controller;

        [TestInitialize]
        public void SetUp()
        {
            _controller = new RoboController();
        }

        [TestMethod]
        public void TestRoboControllerReturnsRobo()
        {
            Assert.IsNotNull(_controller);

            var robo = _controller.Get();
            Assert.IsNotNull(robo);

            Assert.IsInstanceOfType(robo, typeof(RoboViewModel));
        }

        [TestMethod]
        public void TestRoboReturnedHasItsArmsConditions()
        {
            Assert.IsNotNull(_controller);

            var robo = _controller.Get();
            Assert.IsNotNull(robo);

            Assert.IsInstanceOfType(robo, typeof(RoboViewModel));

            Assert.IsNotNull(robo.BracoDireito);
            Assert.IsNotNull(robo.BracoEsquerdo);

            Assert.IsNotNull(robo.BracoDireito.Cotovelo);
            Assert.IsNotNull(robo.BracoDireito.CotoveloDescricao);
            Assert.IsNotNull(robo.BracoDireito.Pulso);
            Assert.IsNotNull(robo.BracoDireito.PulsoDescricao);

            Assert.IsNotNull(robo.BracoEsquerdo.Cotovelo);
            Assert.IsNotNull(robo.BracoEsquerdo.CotoveloDescricao);
            Assert.IsNotNull(robo.BracoEsquerdo.Pulso);
            Assert.IsNotNull(robo.BracoEsquerdo.PulsoDescricao);
        }

        [TestMethod]
        public void TestRoboReturnedHasItsHeadConditions()
        {
            Assert.IsNotNull(_controller);

            var robo = _controller.Get();
            Assert.IsNotNull(robo);

            Assert.IsInstanceOfType(robo, typeof(RoboViewModel));

            Assert.IsNotNull(robo.Cabeca);

            Assert.IsNotNull(robo.Cabeca.Rotacao);
            Assert.IsNotNull(robo.Cabeca.Inclinacao);
        }
    }
}
