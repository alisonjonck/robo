using Domain.Resources;

namespace Domain
{
    public class Cabeca : ICabecaViewModel
    {
        public Cabeca()
        {
        }

        private EnumRotacao _rotacao = EnumRotacao.EmRepouso;
        public EnumRotacao Rotacao
        {
            get { return _rotacao; }
            set
            {
                if (_rotacao != value)
                {
                    if (Inclinacao == EnumInclinacao.ParaBaixo)
                        throw new RoboException(RoboMensagem.SoPoderaRotacionarCabecaComInclinacaoDiferenteDeParaBaixo);

                    if (!((int)_rotacao).IsProgressiveFor((int)value))
                        throw new RoboException(string.Format(RoboMensagem.NecessarioProgressaoCrescenteOuDecrescente, RotacaoDescricao, value.Description()));

                    _rotacao = value;
                }
            }
        }

        public string RotacaoDescricao
        {
            get { return Rotacao.Description(); }
        }

        private EnumInclinacao _inclinacao = EnumInclinacao.EmRepouso;
        public EnumInclinacao Inclinacao
        {
            get { return _inclinacao; }
            set
            {
                if (_inclinacao != value && !((int)_inclinacao).IsProgressiveFor((int)value))
                    throw new RoboException(string.Format(RoboMensagem.NecessarioProgressaoCrescenteOuDecrescente, InclinacaoDescricao, value.Description()));

                _inclinacao = value;
            }
        }

        public string InclinacaoDescricao
        {
            get { return Inclinacao.Description(); }
        }
    }
}
