namespace Domain
{
    public class Cabeca
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
                if (Inclinacao == EnumInclinacao.ParaBaixo)
                    throw new RoboException(RoboMensagem.SoPoderaRotacionarCabecaComInclinacaoDiferenteDeParaBaixo);

                if (!((int)_rotacao + 1 == (int)value || (int)_rotacao - 1 == (int)value))
                    throw new RoboException(RoboMensagem.NecessarioProgressaoCrescenteOuDecrescente);

                _rotacao = value;
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
                if (!((int)_inclinacao + 1 == (int)value || (int)_inclinacao - 1 == (int)value))
                    throw new RoboException(RoboMensagem.NecessarioProgressaoCrescenteOuDecrescente);

                _inclinacao = value;
            }
        }


        public string InclinacaoDescricao
        {
            get { return Inclinacao.Description(); }
        }
    }
}
