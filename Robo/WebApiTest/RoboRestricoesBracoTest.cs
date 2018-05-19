using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiTest
{
    public partial class RoboRestricoesTest
    {
        [TestMethod]
        public void TestProgressaoDeEstadosCotovelosBracosCrescenteDecrescente()
        {
            // 1
            Assert.AreEqual(EnumCotovelo.EmRepouso, _robo.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumCotovelo.EmRepouso, _robo.BracoEsquerdo.Cotovelo);

            // Não deve permitir ir para o 3
            Assert.ThrowsException<RoboException>(() => _robo.BracoDireito.Cotovelo = EnumCotovelo.Contraido, "Progressão de Inclinação deve ser sequencial");
            Assert.ThrowsException<RoboException>(() => _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.Contraido, "Progressão de Inclinação deve ser sequencial");
            // Não deve permitir ir para o 4
            Assert.ThrowsException<RoboException>(() => _robo.BracoDireito.Cotovelo = EnumCotovelo.FortementeContraido, "Progressão de Inclinação deve ser sequencial");
            Assert.ThrowsException<RoboException>(() => _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.FortementeContraido, "Progressão de Inclinação deve ser sequencial");

            // 2
            _robo.BracoDireito.Cotovelo = EnumCotovelo.LevementeContraido;
            _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.LevementeContraido;
            Assert.AreEqual(EnumCotovelo.LevementeContraido, _robo.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumCotovelo.LevementeContraido, _robo.BracoEsquerdo.Cotovelo);

            // Não deve permitir ir para o 4
            Assert.ThrowsException<RoboException>(() => _robo.BracoDireito.Cotovelo = EnumCotovelo.FortementeContraido, "Progressão de Inclinação deve ser sequencial");
            Assert.ThrowsException<RoboException>(() => _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.FortementeContraido, "Progressão de Inclinação deve ser sequencial");

            // 3
            _robo.BracoDireito.Cotovelo = EnumCotovelo.Contraido;
            _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.Contraido;
            Assert.AreEqual(EnumCotovelo.Contraido, _robo.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumCotovelo.Contraido, _robo.BracoEsquerdo.Cotovelo);

            // Não deve permitir ir para o 1
            Assert.ThrowsException<RoboException>(() => _robo.BracoDireito.Cotovelo = EnumCotovelo.EmRepouso, "Progressão de Inclinação deve ser sequencial");
            Assert.ThrowsException<RoboException>(() => _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.EmRepouso, "Progressão de Inclinação deve ser sequencial");

            // 4
            _robo.BracoDireito.Cotovelo = EnumCotovelo.FortementeContraido;
            _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.FortementeContraido;
            Assert.AreEqual(EnumCotovelo.FortementeContraido, _robo.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumCotovelo.FortementeContraido, _robo.BracoEsquerdo.Cotovelo);

            // Não deve permitir ir para o 2
            Assert.ThrowsException<RoboException>(() => _robo.BracoDireito.Cotovelo = EnumCotovelo.LevementeContraido, "Progressão de Inclinação deve ser sequencial");
            Assert.ThrowsException<RoboException>(() => _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.LevementeContraido, "Progressão de Inclinação deve ser sequencial");
            // Não deve permitir ir para o 1
            Assert.ThrowsException<RoboException>(() => _robo.BracoDireito.Cotovelo = EnumCotovelo.EmRepouso, "Progressão de Inclinação deve ser sequencial");
            Assert.ThrowsException<RoboException>(() => _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.EmRepouso, "Progressão de Inclinação deve ser sequencial");

            // 3
            _robo.BracoDireito.Cotovelo = EnumCotovelo.Contraido;
            _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.Contraido;
            Assert.AreEqual(EnumCotovelo.Contraido, _robo.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumCotovelo.Contraido, _robo.BracoEsquerdo.Cotovelo);

            // 2
            _robo.BracoDireito.Cotovelo = EnumCotovelo.LevementeContraido;
            _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.LevementeContraido;
            Assert.AreEqual(EnumCotovelo.LevementeContraido, _robo.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumCotovelo.LevementeContraido, _robo.BracoEsquerdo.Cotovelo);

            // 1
            _robo.BracoDireito.Cotovelo = EnumCotovelo.EmRepouso;
            _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.EmRepouso;
            Assert.AreEqual(EnumCotovelo.EmRepouso, _robo.BracoDireito.Cotovelo);
            Assert.AreEqual(EnumCotovelo.EmRepouso, _robo.BracoEsquerdo.Cotovelo);
        }

        [TestMethod]
        public void TestProgressaoDeEstadosPulsosBracosCrescenteDecrescente()
        {
            // 3
            Assert.AreEqual(EnumPulso.EmRepouso, _robo.BracoDireito.Pulso);
            Assert.AreEqual(EnumPulso.EmRepouso, _robo.BracoEsquerdo.Pulso);

            // Cotovelo deve estar fortemente contraído
            _robo.BracoDireito.Cotovelo = EnumCotovelo.LevementeContraido;
            _robo.BracoDireito.Cotovelo = EnumCotovelo.Contraido;
            _robo.BracoDireito.Cotovelo = EnumCotovelo.FortementeContraido;
            _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.LevementeContraido;
            _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.Contraido;
            _robo.BracoEsquerdo.Cotovelo = EnumCotovelo.FortementeContraido;

            // 2
            assertProgressivenessPulsos(EnumPulso.RotacaoMenos45);

            // 1
            assertProgressivenessPulsos(EnumPulso.RotacaoMenos90);
            assertThrowsExceptionPulsos(EnumPulso.EmRepouso); // 3
            assertThrowsExceptionPulsos(EnumPulso.Rotacao45); // 4
            assertThrowsExceptionPulsos(EnumPulso.Rotacao90); // 5
            assertThrowsExceptionPulsos(EnumPulso.Rotacao135); // 6
            assertThrowsExceptionPulsos(EnumPulso.Rotacao180); // 7

            // 2
            assertProgressivenessPulsos(EnumPulso.RotacaoMenos45);
            assertThrowsExceptionPulsos(EnumPulso.Rotacao45); // 4
            assertThrowsExceptionPulsos(EnumPulso.Rotacao90); // 5
            assertThrowsExceptionPulsos(EnumPulso.Rotacao135); // 6
            assertThrowsExceptionPulsos(EnumPulso.Rotacao180); // 7

            // 3
            assertProgressivenessPulsos(EnumPulso.EmRepouso);
            assertThrowsExceptionPulsos(EnumPulso.RotacaoMenos90); // 1
            assertThrowsExceptionPulsos(EnumPulso.Rotacao90); // 5
            assertThrowsExceptionPulsos(EnumPulso.Rotacao135); // 6
            assertThrowsExceptionPulsos(EnumPulso.Rotacao180); // 7

            // 4
            assertProgressivenessPulsos(EnumPulso.Rotacao45);
            assertThrowsExceptionPulsos(EnumPulso.RotacaoMenos90); // 1
            assertThrowsExceptionPulsos(EnumPulso.RotacaoMenos45); // 2
            assertThrowsExceptionPulsos(EnumPulso.Rotacao135); // 6
            assertThrowsExceptionPulsos(EnumPulso.Rotacao180); // 7

            // 5
            assertProgressivenessPulsos(EnumPulso.Rotacao90);
            assertThrowsExceptionPulsos(EnumPulso.RotacaoMenos90); // 1
            assertThrowsExceptionPulsos(EnumPulso.RotacaoMenos45); // 2
            assertThrowsExceptionPulsos(EnumPulso.EmRepouso); // 3
            assertThrowsExceptionPulsos(EnumPulso.Rotacao180); // 7

            // 6
            assertProgressivenessPulsos(EnumPulso.Rotacao135);
            assertThrowsExceptionPulsos(EnumPulso.RotacaoMenos90); // 1
            assertThrowsExceptionPulsos(EnumPulso.RotacaoMenos45); // 2
            assertThrowsExceptionPulsos(EnumPulso.EmRepouso); // 3
            assertThrowsExceptionPulsos(EnumPulso.Rotacao45); // 4

            // 7
            assertProgressivenessPulsos(EnumPulso.Rotacao180);
            assertThrowsExceptionPulsos(EnumPulso.RotacaoMenos90); // 1
            assertThrowsExceptionPulsos(EnumPulso.RotacaoMenos45); // 2
            assertThrowsExceptionPulsos(EnumPulso.EmRepouso); // 3
            assertThrowsExceptionPulsos(EnumPulso.Rotacao45); // 4
            assertThrowsExceptionPulsos(EnumPulso.Rotacao90); // 5
        }

        private void assertProgressivenessPulsos(EnumPulso enumerador)
        {
            _robo.BracoDireito.Pulso = enumerador;
            _robo.BracoEsquerdo.Pulso = enumerador;
            Assert.AreEqual(enumerador, _robo.BracoDireito.Pulso);
            Assert.AreEqual(enumerador, _robo.BracoEsquerdo.Pulso);
        }

        private void assertThrowsExceptionPulsos(EnumPulso enumerador)
        {
            Assert.ThrowsException<RoboException>(() => _robo.BracoDireito.Pulso = enumerador, "Progressão de Inclinação deve ser sequencial");
            Assert.ThrowsException<RoboException>(() => _robo.BracoEsquerdo.Pulso = enumerador, "Progressão de Inclinação deve ser sequencial");
        }
    }
}
