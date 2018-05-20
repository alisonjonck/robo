using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using ViewModel;

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

        [TestMethod]
        public void TestRoboServiceUpdateRoboShouldChangeAllStates()
        {
            var roboService = new RoboService();
            Assert.IsNotNull(roboService);
            Assert.IsInstanceOfType(roboService, typeof(IRoboService));

            IRoboViewModel roboAtualizado = new RoboViewModel(roboService.GetRobo());
            // Cabeça Inclinação
            Assert.AreEqual(EnumInclinacao.EmRepouso, roboAtualizado.Cabeca.Inclinacao);
            roboAtualizado.Cabeca.Inclinacao = EnumInclinacao.ParaCima;
            // Cabeça Rotação
            Assert.AreEqual(EnumRotacao.EmRepouso, roboAtualizado.Cabeca.Rotacao);
            roboAtualizado.Cabeca.Rotacao = EnumRotacao.Rotacao45;

            // Braço Direito Cotovelo
            Assert.AreEqual(EnumCotovelo.EmRepouso, roboAtualizado.BracoDireito.Cotovelo);
            roboAtualizado.BracoDireito.Cotovelo = EnumCotovelo.LevementeContraido;
            roboService.UpdateRobo(roboAtualizado);
            roboAtualizado.BracoDireito.Cotovelo = EnumCotovelo.Contraido;
            roboService.UpdateRobo(roboAtualizado);
            roboAtualizado.BracoDireito.Cotovelo = EnumCotovelo.FortementeContraido;
            
            // Braço Esquerdo Cotovelo
            Assert.AreEqual(EnumCotovelo.EmRepouso, roboAtualizado.BracoEsquerdo.Cotovelo);
            roboAtualizado.BracoEsquerdo.Cotovelo = EnumCotovelo.LevementeContraido;
            roboService.UpdateRobo(roboAtualizado);
            roboAtualizado.BracoEsquerdo.Cotovelo = EnumCotovelo.Contraido;
            roboService.UpdateRobo(roboAtualizado);
            roboAtualizado.BracoEsquerdo.Cotovelo = EnumCotovelo.FortementeContraido;

            // Importante: Só poderá movimentar pulso com Cotovelo fortemente contraído
            // Braço Direito Pulso
            Assert.AreEqual(EnumPulso.EmRepouso, roboAtualizado.BracoDireito.Pulso);
            roboAtualizado.BracoDireito.Pulso = EnumPulso.Rotacao45;
            // Braço Esquerdo Pulso
            Assert.AreEqual(EnumPulso.EmRepouso, roboAtualizado.BracoEsquerdo.Pulso);
            roboAtualizado.BracoEsquerdo.Pulso = EnumPulso.Rotacao45;

            var resultUpdate = roboService.UpdateRobo(roboAtualizado);

            Assert.AreEqual(EnumInclinacao.ParaCima, resultUpdate.Cabeca.Inclinacao);
            Assert.AreEqual(EnumRotacao.Rotacao45, resultUpdate.Cabeca.Rotacao);
            Assert.AreEqual(EnumCotovelo.FortementeContraido, resultUpdate.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumPulso.Rotacao45, resultUpdate.BracoDireito.Pulso);
            Assert.AreEqual(EnumCotovelo.FortementeContraido, resultUpdate.BracoEsquerdo.Cotovelo);
            Assert.AreEqual(EnumPulso.Rotacao45, resultUpdate.BracoEsquerdo.Pulso);

            var roboUptaded = roboService.GetRobo();
            Assert.AreEqual(EnumInclinacao.ParaCima, resultUpdate.Cabeca.Inclinacao);
            Assert.AreEqual(EnumRotacao.Rotacao45, resultUpdate.Cabeca.Rotacao);
            Assert.AreEqual(EnumCotovelo.FortementeContraido, resultUpdate.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumPulso.Rotacao45, resultUpdate.BracoDireito.Pulso);
            Assert.AreEqual(EnumCotovelo.FortementeContraido, resultUpdate.BracoEsquerdo.Cotovelo);
            Assert.AreEqual(EnumPulso.Rotacao45, resultUpdate.BracoEsquerdo.Pulso);
        }
    }
}
