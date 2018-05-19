using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiTest
{
    [TestClass]
    public class RoboTest
    {
        private Robo _robo;

        [TestInitialize]
        public void SetUp()
        {
            _robo = new Robo();
        }

        [TestMethod]
        public void TestRoboExists()
        {
            Assert.IsNotNull(_robo);
        }

        [TestMethod]
        public void TestRoboHasArmsWithElbowAndWrist()
        {
            Assert.IsNotNull(_robo);

            Assert.IsNotNull(_robo.BracoDireito);
            Assert.IsNotNull(_robo.BracoEsquerdo);

            Assert.IsNotNull(_robo.BracoDireito.Cotovelo);
            Assert.IsNotNull(_robo.BracoDireito.Pulso);

            Assert.IsNotNull(_robo.BracoEsquerdo.Cotovelo);
            Assert.IsNotNull(_robo.BracoEsquerdo.Pulso);
        }

        [TestMethod]
        public void TestRobosElbowStartsWithEmRepouso()
        {
            Assert.IsNotNull(_robo.BracoDireito.Cotovelo);
            Assert.IsNotNull(_robo.BracoEsquerdo.Cotovelo);
            Assert.AreEqual(EnumCotovelo.EmRepouso, _robo.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumCotovelo.EmRepouso, _robo.BracoEsquerdo.Cotovelo);
            Assert.AreEqual("Em Repouso", _robo.BracoDireito.CotoveloDescricao);
            Assert.AreEqual("Em Repouso", _robo.BracoEsquerdo.CotoveloDescricao);
        }

        [TestMethod]
        public void TestRobosElbowHasValidOptions()
        {
            Assert.AreEqual((int)EnumCotovelo.EmRepouso, 1);
            Assert.AreEqual((int)EnumCotovelo.LevementeContraido, 2);
            Assert.AreEqual((int)EnumCotovelo.Contraido, 3);
            Assert.AreEqual((int)EnumCotovelo.FortementeContraido, 4);

            Assert.AreEqual(EnumCotovelo.EmRepouso.Description(), "Em Repouso");
            Assert.AreEqual(EnumCotovelo.LevementeContraido.Description(), "Levemente Contra�do");
            Assert.AreEqual(EnumCotovelo.Contraido.Description(), "Contra�do");
            Assert.AreEqual(EnumCotovelo.FortementeContraido.Description(), "Fortemente Contra�do");
        }

        [TestMethod]
        public void TestRobosWristStartsWithEmRepouso()
        {
            Assert.IsNotNull(_robo.BracoDireito.Pulso);
            Assert.AreEqual(EnumPulso.EmRepouso, _robo.BracoDireito.Pulso);
            Assert.AreEqual("Em Repouso", _robo.BracoDireito.PulsoDescricao);
        }

        [TestMethod]
        public void TestRobosWristHasValidOptions()
        {
            Assert.AreEqual((int)EnumPulso.EmRepouso, 3);
            Assert.AreEqual((int)EnumPulso.Rotacao135, 6);
            Assert.AreEqual((int)EnumPulso.Rotacao180, 7);
            Assert.AreEqual((int)EnumPulso.Rotacao45, 4);
            Assert.AreEqual((int)EnumPulso.Rotacao90, 5);
            Assert.AreEqual((int)EnumPulso.RotacaoMenos45, 2);
            Assert.AreEqual((int)EnumPulso.RotacaoMenos90, 1);

            Assert.AreEqual(EnumPulso.EmRepouso.Description(), "Em Repouso");
            Assert.AreEqual(EnumPulso.Rotacao135.Description(), "Rota��o para 135�");
            Assert.AreEqual(EnumPulso.Rotacao180.Description(), "Rota��o para 180�");
            Assert.AreEqual(EnumPulso.Rotacao45.Description(), "Rota��o para 45�");
            Assert.AreEqual(EnumPulso.Rotacao90.Description(), "Rota��o para 90�");
            Assert.AreEqual(EnumPulso.RotacaoMenos45.Description(), "Rota��o para -45�");
            Assert.AreEqual(EnumPulso.RotacaoMenos90.Description(), "Rota��o para -90�");
        }

        [TestMethod]
        public void TestRoboHasHeadWithRotationAndInclination()
        {
            Assert.IsNotNull(_robo);

            Assert.IsNotNull(_robo.Cabeca);

            Assert.IsNotNull(_robo.Cabeca.Rotacao);
            Assert.IsNotNull(_robo.Cabeca.Inclinacao);
        }

        [TestMethod]
        public void TestRobosRotationStartsWithEmRepouso()
        {
            Assert.IsNotNull(_robo.Cabeca.Rotacao);
            Assert.AreEqual(EnumRotacao.EmRepouso, _robo.Cabeca.Rotacao);
            Assert.AreEqual("Em Repouso", _robo.Cabeca.RotacaoDescricao);
        }

        [TestMethod]
        public void TestRobosRotationHasValidOptions()
        {
            Assert.AreEqual((int)EnumRotacao.RotacaoMenos90, 1);
            Assert.AreEqual((int)EnumRotacao.RotacaoMenos45, 2);
            Assert.AreEqual((int)EnumRotacao.EmRepouso, 3);
            Assert.AreEqual((int)EnumRotacao.Rotacao45, 4);
            Assert.AreEqual((int)EnumRotacao.Rotacao90, 5);

            Assert.AreEqual(EnumRotacao.RotacaoMenos90.Description(), "Rota��o -90�");
            Assert.AreEqual(EnumRotacao.RotacaoMenos45.Description(), "Rota��o -45�");
            Assert.AreEqual(EnumRotacao.EmRepouso.Description(), "Em Repouso");
            Assert.AreEqual(EnumRotacao.Rotacao45.Description(), "Rota��o 45�");
            Assert.AreEqual(EnumRotacao.Rotacao90.Description(), "Rota��o 90�");
        }

        [TestMethod]
        public void TestRobosInclinationStartsWithEmRepouso()
        {
            Assert.IsNotNull(_robo.Cabeca.Inclinacao);
            Assert.AreEqual(EnumInclinacao.EmRepouso, _robo.Cabeca.Inclinacao);
            Assert.AreEqual("Em Repouso", _robo.Cabeca.InclinacaoDescricao);
        }

        [TestMethod]
        public void TestRobosInclinationHasValidOptions()
        {
            Assert.AreEqual((int)EnumInclinacao.EmRepouso, 2);
            Assert.AreEqual((int)EnumInclinacao.ParaBaixo, 3);
            Assert.AreEqual((int)EnumInclinacao.ParaCima, 1);

            Assert.AreEqual(EnumInclinacao.EmRepouso.Description(), "Em Repouso");
            Assert.AreEqual(EnumInclinacao.ParaBaixo.Description(), "Para Baixo");
            Assert.AreEqual(EnumInclinacao.ParaCima.Description(), "Para Cima");
        }
    }
}
