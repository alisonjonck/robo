using Domain;

namespace ViewModel
{
    public class CabecaViewModel : ICabecaViewModel
    {
        public CabecaViewModel()
        {

        }

        public EnumRotacao Rotacao { get; set; } = EnumRotacao.EmRepouso;

        public string RotacaoDescricao
        {
            get { return Rotacao.Description(); }
        }

        public EnumInclinacao Inclinacao { get; set; } = EnumInclinacao.EmRepouso;

        public string InclinacaoDescricao
        {
            get { return Inclinacao.Description(); }
        }
    }
}
