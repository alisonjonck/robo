namespace Domain
{
    public class Braco
    {
        public Braco()
        {
            Cotovelo = EnumCotovelo.EmRepouso;
            Pulso = "";
        }

        public EnumCotovelo Cotovelo { get; set; }

        public string CotoveloDescricao
        {
            get { return Cotovelo.Description(); }
        }

        public string Pulso { get; set; }
    }
}
