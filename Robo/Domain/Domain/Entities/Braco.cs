﻿using Domain.Resources;

namespace Domain
{
    public class Braco
    {
        public Braco()
        {
        }

        private EnumCotovelo _cotovelo = EnumCotovelo.EmRepouso;
        public EnumCotovelo Cotovelo
        {
            get { return _cotovelo; }
            set
            {
                if (_cotovelo != value && !((int)_cotovelo + 1 == (int)value || (int)_cotovelo - 1 == (int)value))
                    throw new RoboException(RoboMensagem.NecessarioProgressaoCrescenteOuDecrescente);

                _cotovelo = value;
            }
        }

        public string CotoveloDescricao
        {
            get { return Cotovelo.Description(); }
        }

        private EnumPulso _pulso = EnumPulso.EmRepouso;
        public EnumPulso Pulso
        {
            get { return _pulso; }
            set
            {
                if (_pulso != value)
                {

                    if (!((int)_pulso + 1 == (int)value || (int)_pulso - 1 == (int)value))
                        throw new RoboException(RoboMensagem.NecessarioProgressaoCrescenteOuDecrescente);

                    if (Cotovelo != EnumCotovelo.FortementeContraido)
                        throw new RoboException(RoboMensagem.SoPoderaMovimentarPulsoComCotoveloFortementeContraido);

                    _pulso = value;
                }
            }
        }

        public string PulsoDescricao
        {
            get { return Pulso.Description(); }
        }
    }
}
