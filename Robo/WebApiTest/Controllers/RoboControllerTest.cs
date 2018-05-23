using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service;
using ViewModel;
using WebApi.Controllers;

namespace WebApiTest.Controllers
{
    [TestClass]
    public class RoboControllerTest
    {
        private RoboController _controller;
        private Mock<ILoggerFactory> _logger;

        [TestInitialize]
        public void SetUp()
        {
            _logger = new Mock<ILoggerFactory>();

            _controller = new RoboController(new RoboService(), _logger.Object);
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

            IRoboViewModel robo = (result as OkObjectResult)?.Value as IRoboViewModel;

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

            IRoboViewModel robo = (result as OkObjectResult)?.Value as IRoboViewModel;

            Assert.IsInstanceOfType(robo, typeof(RoboViewModel));

            Assert.IsNotNull(robo.Cabeca);

            Assert.IsNotNull(robo.Cabeca.Rotacao);
            Assert.IsNotNull(robo.Cabeca.Inclinacao);
        }

        [TestMethod]
        public void TestRoboControllerGetReturnsHandledException()
        {
            var mockedLogger = new Mock<ILogger>();

            _logger.Setup(l => l.CreateLogger("RoboApi.Controllers.RoboController"))
                .Returns(mockedLogger.Object);

            _controller = new RoboController(null, _logger.Object);

            var result = _controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var exception = (result as OkObjectResult)?.Value as HandledException;

            Assert.IsInstanceOfType(exception, typeof(HandledException));

            Assert.IsNotNull(exception.Mensagem);
        }

        [TestMethod]
        public void TestRoboControllerPutReturnsHandledException()
        {
            _controller = new RoboController(null, _logger.Object);

            var result = _controller.Put(new RoboViewModel());

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var exception = (result as OkObjectResult)?.Value as HandledException;

            Assert.IsInstanceOfType(exception, typeof(HandledException));

            Assert.IsNotNull(exception.Mensagem);
        }

        [TestMethod]
        public void TestRoboControllerPutReturnsHandledRoboException()
        {
            var result = _controller.Put(new RoboViewModel()
            {
                BracoDireito = new BracoViewModel()
                {
                    // Estado inválido para Cotovelo que estará em repouso
                    Cotovelo = EnumCotovelo.FortementeContraido
                }
            });

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var exception = (result as OkObjectResult)?.Value as HandledException;

            Assert.IsInstanceOfType(exception, typeof(HandledException));

            Assert.IsNotNull(exception.Mensagem);
            Assert.AreEqual("\"Em Repouso\" não pode mudar para \"Fortemente Contraído\". É necessário que sempre siga a ordem crescente ou decrescente.",
                exception.Mensagem);
        }

        [TestMethod]
        public void TestRoboControllerPutUpdatesRobo()
        {
            Assert.IsNotNull(_controller);

            var robo = new RoboViewModel();
            robo.BracoDireito.Cotovelo = EnumCotovelo.LevementeContraido;

            var result = _controller.Put(robo);
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            IRoboViewModel roboAtualizado = (_controller.Get() as OkObjectResult)?.Value as IRoboViewModel;

            Assert.AreEqual(EnumCotovelo.LevementeContraido, roboAtualizado.BracoDireito.Cotovelo);
        }
    }
}
