namespace Domain
{
    public class Cabeca
    {
        public Cabeca()
        {
            Rotacao = EnumRotacao.EmRepouso;
            Inclinacao = EnumInclinacao.EmRepouso;
        }

        public EnumRotacao Rotacao { get; set; }

        public string RotacaoDescricao
        {
            get { return Rotacao.Description(); }
        }

        public EnumInclinacao Inclinacao { get; set; }

        public string InclinacaoDescricao
        {
            get { return Inclinacao.Description(); }
        }
    }
}
