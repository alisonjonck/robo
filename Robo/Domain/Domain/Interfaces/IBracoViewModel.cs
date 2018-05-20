namespace Domain
{
    public interface IBracoViewModel
    {
        EnumCotovelo Cotovelo { get; set; }

        string CotoveloDescricao { get; }

        EnumPulso Pulso { get; set; }

        string PulsoDescricao { get; }
    }
}
