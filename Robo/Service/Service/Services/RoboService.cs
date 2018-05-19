using Domain;

namespace Service
{
    public class RoboService : IRoboService
    {
        private readonly Robo _robo;

        public RoboService()
        {
            _robo = new Robo();
        }

        public Robo GetRobo()
        {
            return _robo;
        }

        public Robo UpdateRobo(Robo robo)
        {
            _robo.BracoDireito.Cotovelo = robo.BracoDireito.Cotovelo;
            _robo.BracoDireito.Pulso = robo.BracoDireito.Pulso;
            _robo.BracoEsquerdo.Cotovelo = robo.BracoEsquerdo.Cotovelo;
            _robo.BracoEsquerdo.Pulso = robo.BracoEsquerdo.Pulso;

            _robo.Cabeca.Inclinacao = robo.Cabeca.Inclinacao;
            _robo.Cabeca.Rotacao = robo.Cabeca.Rotacao;

            return GetRobo();
        }
    }
}
