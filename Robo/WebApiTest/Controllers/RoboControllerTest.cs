using Microsoft.AspNetCore.Mvc;
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
        public void TestRoboControllerGetReturnsRobo()
        {
            Assert.IsNotNull(_controller);

            var result = _controller.Get();
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var robo = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(robo, typeof(RoboViewModel));
        }

        [TestMethod]
        public void TestRoboReturnedHasItsArmsConditions()
        {
            Assert.IsNotNull(_controller);

            var result = _controller.Get();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            RoboViewModel robo = (result as OkObjectResult)?.Value as RoboViewModel;

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

            var result = _controller.Get();
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            RoboViewModel robo = (result as OkObjectResult)?.Value as RoboViewModel;

            Assert.IsInstanceOfType(robo, typeof(RoboViewModel));

            Assert.IsNotNull(robo.Cabeca);

            Assert.IsNotNull(robo.Cabeca.Rotacao);
            Assert.IsNotNull(robo.Cabeca.Inclinacao);
        }

        [TestMethod]
        public void TestRoboControllerPutUpdatesRobo()
        {
            Assert.IsNotNull(_controller);

            var robo = new RoboViewModel();

            var result = _controller.Put(robo);

            Assert.IsNotNull(result);
        }
    }
}
