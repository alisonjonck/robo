namespace Domain
{
    public interface IRoboViewModel
    {
        Cabeca Cabeca { get; set; }

        Braco BracoDireito { get; set; }

        Braco BracoEsquerdo { get; set; }
    }
}
