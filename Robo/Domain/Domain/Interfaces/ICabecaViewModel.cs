namespace Domain
{
    public interface ICabecaViewModel
    {
        EnumRotacao Rotacao { get; set; }

        string RotacaoDescricao { get; }

        EnumInclinacao Inclinacao { get; set; }

        string InclinacaoDescricao { get; }
    }
}
