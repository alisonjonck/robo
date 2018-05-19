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
        }

        [TestMethod]
        public void TestRobosElbowStartsWithEmRepouso()
        {
            Assert.IsNotNull(_robo.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumCotovelo.EmRepouso, _robo.BracoDireito.Cotovelo);
            Assert.AreEqual("Em Repouso", _robo.BracoDireito.CotoveloDescricao);
        }

        [TestMethod]
        public void TestRobosElbowHasValidOptions()
        {
            Assert.AreEqual((int)EnumCotovelo.EmRepouso, 0);
            Assert.AreEqual((int)EnumCotovelo.LevementeContraido, 1);
            Assert.AreEqual((int)EnumCotovelo.Contraido, 2);
            Assert.AreEqual((int)EnumCotovelo.FortementeContraido, 3);

            Assert.AreEqual(EnumCotovelo.EmRepouso.Description(), "Em Repouso");
            Assert.AreEqual(EnumCotovelo.LevementeContraido.Description(), "Levemente Contraído");
            Assert.AreEqual(EnumCotovelo.Contraido.Description(), "Contraído");
            Assert.AreEqual(EnumCotovelo.FortementeContraido.Description(), "Fortemente Contraído");
        }
    }
}
