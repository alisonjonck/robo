using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiTest
{
    [TestClass]
    public partial class RoboRestricoesTest
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

            // Cotovelo deve ficar Fortemente Contraído
            _robo.BracoDireito.Cotovelo = EnumCotovelo.LevementeContraido;
            _robo.BracoDireito.Cotovelo = EnumCotovelo.Contraido;
            _robo.BracoDireito.Cotovelo = EnumCotovelo.FortementeContraido;
            Assert.AreEqual(EnumCotovelo.FortementeContraido, _robo.BracoDireito.Cotovelo);

            // vai para o '2' devido restrição de progressão
            _robo.BracoDireito.Pulso = EnumPulso.RotacaoMenos45;

            Assert.AreEqual(EnumPulso.RotacaoMenos45, _robo.BracoDireito.Pulso);
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

        #region TEST PROGRESSÃO DE ESTADOS
        // ###############################################################################
        // Ao realizar a progressão de estados, é necessário que sempre siga a ordem
        // crescente ou decrescente, por exemplo, a partir do estado 4, pode-se ir para
        // os estados 3 ou 5, nunca pulando um estado.
        // ###############################################################################

        [TestMethod]
        public void TestProgressaoDeEstadosInclinacaoCabecaCrescenteDecrescente()
        {
            // 2
            Assert.AreEqual(EnumInclinacao.EmRepouso, _robo.Cabeca.Inclinacao);

            // 3
            _robo.Cabeca.Inclinacao = EnumInclinacao.ParaBaixo;
            Assert.AreEqual(EnumInclinacao.ParaBaixo, _robo.Cabeca.Inclinacao);

            // Não deve permitir ir para o 1
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Inclinacao = EnumInclinacao.ParaCima;

            }, "Progressão de Inclinação deve ser sequencial");

            // 2
            _robo.Cabeca.Inclinacao = EnumInclinacao.EmRepouso;
            Assert.AreEqual(EnumInclinacao.EmRepouso, _robo.Cabeca.Inclinacao);

            // 1
            _robo.Cabeca.Inclinacao = EnumInclinacao.ParaCima;
            Assert.AreEqual(EnumInclinacao.ParaCima, _robo.Cabeca.Inclinacao);

            // Não deve permitir ir para o 3
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Inclinacao = EnumInclinacao.ParaBaixo;

            }, "Progressão de Inclinação deve ser sequencial");
        }

        [TestMethod]
        public void TestProgressaoDeEstadosRotacaoCabecaCrescenteDecrescente()
        {
            // 3
            Assert.AreEqual(EnumRotacao.EmRepouso, _robo.Cabeca.Rotacao);

            // Não deve permitir ir para o 1
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.RotacaoMenos90;

            }, "Progressão de Inclinação deve ser sequencial");
            // Não deve permitir ir para o 5
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.Rotacao90;

            }, "Progressão de Inclinação deve ser sequencial");

            // 4
            _robo.Cabeca.Rotacao = EnumRotacao.Rotacao45;
            Assert.AreEqual(EnumRotacao.Rotacao45, _robo.Cabeca.Rotacao);

            // Não deve permitir ir para o 1
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.RotacaoMenos90;

            }, "Progressão de Inclinação deve ser sequencial");
            // Não deve permitir ir para o 2
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.RotacaoMenos45;

            }, "Progressão de Inclinação deve ser sequencial");

            // 5
            _robo.Cabeca.Rotacao = EnumRotacao.Rotacao90;
            Assert.AreEqual(EnumRotacao.Rotacao90, _robo.Cabeca.Rotacao);

            // Não deve permitir ir para o 3
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.EmRepouso;

            }, "Progressão de Inclinação deve ser sequencial");
            // Não deve permitir ir para o 2
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.RotacaoMenos45;

            }, "Progressão de Inclinação deve ser sequencial");
            // Não deve permitir ir para o 1
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.RotacaoMenos90;

            }, "Progressão de Inclinação deve ser sequencial");

            // 4
            _robo.Cabeca.Rotacao = EnumRotacao.Rotacao45;
            Assert.AreEqual(EnumRotacao.Rotacao45, _robo.Cabeca.Rotacao);

            // 3
            _robo.Cabeca.Rotacao = EnumRotacao.EmRepouso;
            Assert.AreEqual(EnumRotacao.EmRepouso, _robo.Cabeca.Rotacao);

            // 2
            _robo.Cabeca.Rotacao = EnumRotacao.RotacaoMenos45;
            Assert.AreEqual(EnumRotacao.RotacaoMenos45, _robo.Cabeca.Rotacao);

            // Não deve permitir ir para o 4
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.Rotacao45;

            }, "Progressão de Inclinação deve ser sequencial");
            // Não deve permitir ir para o 5
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.Rotacao90;

            }, "Progressão de Inclinação deve ser sequencial");

            // 1
            _robo.Cabeca.Rotacao = EnumRotacao.RotacaoMenos90;
            Assert.AreEqual(EnumRotacao.RotacaoMenos90, _robo.Cabeca.Rotacao);

            // Não deve permitir ir para o 3
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.EmRepouso;

            }, "Progressão de Inclinação deve ser sequencial");
            // Não deve permitir ir para o 4
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.Rotacao45;

            }, "Progressão de Inclinação deve ser sequencial");
            // Não deve permitir ir para o 5
            Assert.ThrowsException<RoboException>(() =>
            {
                _robo.Cabeca.Rotacao = EnumRotacao.Rotacao90;

            }, "Progressão de Inclinação deve ser sequencial");
        }

        #endregion
    }
}
