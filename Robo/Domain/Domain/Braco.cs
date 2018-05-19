namespace Domain
{
    public class Braco
    {
        public Braco()
        {
        }

        public EnumCotovelo Cotovelo { get; set; } = EnumCotovelo.EmRepouso;

        public string CotoveloDescricao
        {
            get { return Cotovelo.Description(); }
        }

        private EnumPulso _pulso = EnumPulso.EmRepouso;
        public EnumPulso Pulso
        {
            get { return _pulso; }
            set
            {
                if (Cotovelo != EnumCotovelo.FortementeContraido)
                    throw new RoboException(RoboMensagem.SoPoderaMovimentarPulsoComCotoveloFortementeContraido);

                _pulso = value;
            }
        }

        public string PulsoDescricao
        {
            get { return Pulso.Description(); }
        }
    }
}
