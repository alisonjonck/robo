using System;

namespace Domain
{
    public class RoboException : Exception
    {
        public RoboException(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; set; }
    }
}
