using System;

namespace Domain
{
    public class Robo
    {
        public Robo()
        {
            BracoDireito = new Braco();
            BracoEsquerdo = new Braco();
            Cabeca = new Cabeca();
        }

        public Braco BracoDireito { get; set; }

        public Braco BracoEsquerdo { get; set; }

        public Cabeca Cabeca { get; set; }
    }
}
