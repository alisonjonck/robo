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

                _rotacao = value;
            }
        }

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
