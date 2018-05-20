namespace Domain
{
    public interface IRoboViewModel
    {
        ICabecaViewModel Cabeca { get; set; }

        IBracoViewModel BracoDireito { get; set; }

        IBracoViewModel BracoEsquerdo { get; set; }
    }
}
