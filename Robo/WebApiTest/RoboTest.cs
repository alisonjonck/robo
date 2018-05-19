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
            Assert.AreEqual(EnumCotovelo.LevementeContraido.Description(), "Levemente Contraído");
            Assert.AreEqual(EnumCotovelo.Contraido.Description(), "Contraído");
            Assert.AreEqual(EnumCotovelo.FortementeContraido.Description(), "Fortemente Contraído");
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
            Assert.AreEqual(EnumPulso.Rotacao135.Description(), "Rotação para 135º");
            Assert.AreEqual(EnumPulso.Rotacao180.Description(), "Rotação para 180º");
            Assert.AreEqual(EnumPulso.Rotacao45.Description(), "Rotação para 45º");
            Assert.AreEqual(EnumPulso.Rotacao90.Description(), "Rotação para 90º");
            Assert.AreEqual(EnumPulso.RotacaoMenos45.Description(), "Rotação para -45º");
            Assert.AreEqual(EnumPulso.RotacaoMenos90.Description(), "Rotação para -90º");
        }

        [TestMethod]
        public void TestRoboHasHeadWithRotationAndInclination()
        {

        }
    }
}
