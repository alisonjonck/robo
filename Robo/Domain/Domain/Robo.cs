using System;

namespace Domain
{
    public class Robo
    {
        public Robo()
        {
            BracoDireito = new Braco();
            BracoEsquerdo = new Braco();
        }

        public Braco BracoDireito { get; set; }

        public Braco BracoEsquerdo { get; set; }
    }
}
