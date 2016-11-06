using System;

namespace GovHackSeduc.Entity
{
    public class AulaAtividade
    {
        public Guid AulaAtividadeId
        {
            get;
            set;
        }

        public Guid AulaId
        {
            get;
            set;
        }

        public string Titulo
        {
            get;
            set;
        }

        public string Detalhe
        {
            get;
            set;
        }

        public string TipoDeAtividade
        {
            get;
            set;
        }
    }
}