namespace Domain
{
    public class Braco
    {
        public Braco()
        {
            Cotovelo = EnumCotovelo.EmRepouso;
            Pulso = EnumPulso.EmRepouso;
        }

        public EnumCotovelo Cotovelo { get; set; }

        public string CotoveloDescricao
        {
            get { return Cotovelo.Description(); }
        }

        public EnumPulso Pulso { get; set; }

        public string PulsoDescricao
        {
            get { return Pulso.Description(); }
        }
    }
}
