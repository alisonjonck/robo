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

            return _robo;
        }
    }
}
