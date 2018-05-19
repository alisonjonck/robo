using Domain;

namespace ViewModel
{
    /// <summary>
    /// R.o.b.o.
    /// </summary>
    public class RoboViewModel
    {
        /// <summary>
        /// R.o.b.o.
        /// </summary>
        public RoboViewModel()
        {
            Cabeca = new Cabeca();
            BracoDireito = new Braco();
            BracoEsquerdo = new Braco();
        }

        public Braco BracoDireito { get; set; }

        public Braco BracoEsquerdo { get; set; }

        public Cabeca Cabeca { get; set; }
    }
}
