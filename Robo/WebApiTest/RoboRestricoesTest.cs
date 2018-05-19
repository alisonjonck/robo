using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiTest
{
    [TestClass]
    public class RoboRestricoesTest
    {
        private Robo _robo;

        [TestInitialize]
        public void SetUp()
        {
            _robo = new Robo();
        }

        /// <summary>
        /// Só poderá movimentar o Pulso caso o Cotovelo esteja Fortemente Contraído.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RoboException), "Movimento de pulso não apropriado seria permitido")]
        public void TestRoboMovimentarPulsoDeveTerCotoveloFortementeContraido()
        {
            Assert.AreEqual(EnumCotovelo.EmRepouso, _robo.BracoDireito.Cotovelo);

            // Cotovelo está diferente de Fortemente Contraído
            Assert.AreNotEqual(EnumCotovelo.FortementeContraido, _robo.BracoDireito.Cotovelo);

            _robo.BracoDireito.Pulso = EnumPulso.Rotacao135;
        }

        /// <summary>
        /// Só poderá movimentar o Pulso caso o Cotovelo esteja Fortemente Contraído.
        /// </summary>
        [TestMethod]
        public void TestRoboMovimentarPulsoAlteraQuandoCotoveloFortementeContraido()
        {
            Assert.AreEqual(EnumCotovelo.EmRepouso, _robo.BracoDireito.Cotovelo);

            // Cotovelo está Fortemente Contraído
            _robo.BracoDireito.Cotovelo = EnumCotovelo.FortementeContraido;
            Assert.AreEqual(EnumCotovelo.FortementeContraido, _robo.BracoDireito.Cotovelo);

            _robo.BracoDireito.Pulso = EnumPulso.Rotacao135;

            Assert.AreEqual(EnumPulso.Rotacao135, _robo.BracoDireito.Pulso);
        }

        /// <summary>
        /// Só poderá Rotacionar a Cabeça caso sua Inclinação da Cabeça não esteja em estado Para Baixo
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RoboException), "Rotação de cabeça não apropriada seria permitida")]
        public void TestRoboRotacionarCabecaDeveTerInclinacaoDiferenteDeParaBaixo()
        {
            _robo.Cabeca.Inclinacao = EnumInclinacao.ParaBaixo;

            // Inclinação está Para Baixo
            Assert.AreEqual(EnumInclinacao.ParaBaixo, _robo.Cabeca.Inclinacao);

            _robo.Cabeca.Rotacao = EnumRotacao.Rotacao45;
        }

        /// <summary>
        /// Só poderá Rotacionar a Cabeça caso sua Inclinação da Cabeça não esteja em estado Para Baixo
        /// </summary>
        [TestMethod]
        public void TestRoboRotacionarCabecaAlteraQuandoInclinacaoDiferenteDeParaBaixo()
        {
            Assert.AreEqual(EnumInclinacao.EmRepouso, _robo.Cabeca.Inclinacao);

            // Inclinação está diferente de Para Baixo
            Assert.AreNotEqual(EnumInclinacao.ParaBaixo, _robo.Cabeca.Inclinacao);

            _robo.Cabeca.Rotacao = EnumRotacao.Rotacao45;
        }

        /// <summary>
        /// Ao realizar a progressão de estados, é necessário que sempre siga a ordem
        /// crescente ou decrescente, por exemplo, a partir do estado 4, pode-se ir para
        /// os estados 3 ou 5, nunca pulando um estado.
        /// </summary>
        [TestMethod]
        public void TestProgressaoDeEstados()
        {
            Assert.Fail("UNDONE");
        }
    }
}
