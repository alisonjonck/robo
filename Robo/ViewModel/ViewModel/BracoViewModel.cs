using Domain;

namespace ViewModel
{
    public class BracoViewModel : IBracoViewModel
    {
        public BracoViewModel()
        {

        }

        public EnumCotovelo Cotovelo { get; set; } = EnumCotovelo.EmRepouso;

        public string CotoveloDescricao
        {
            get { return Cotovelo.Description(); }
        }

        public EnumPulso Pulso { get; set; } = EnumPulso.EmRepouso;

        public string PulsoDescricao
        {
            get { return Pulso.Description(); }
        }
    }
}
