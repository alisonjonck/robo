using Domain;

namespace ViewModel
{
    /// <summary>
    /// R.o.b.o.
    /// </summary>
    public class RoboViewModel : IRoboViewModel
    {
        /// <summary>
        /// R.o.b.o.
        /// </summary>
        public RoboViewModel()
        {
            Cabeca = new CabecaViewModel();
            BracoDireito = new BracoViewModel();
            BracoEsquerdo = new BracoViewModel();
        }

        /// <summary>
        /// R.o.b.o.
        /// </summary>
        public RoboViewModel(Robo robo)
        {
            Cabeca = robo.Cabeca;
            BracoDireito = robo.BracoDireito;
            BracoEsquerdo = robo.BracoEsquerdo;
        }

        public IBracoViewModel BracoDireito { get; set; }

        public IBracoViewModel BracoEsquerdo { get; set; }

        public ICabecaViewModel Cabeca { get; set; }
    }
}
