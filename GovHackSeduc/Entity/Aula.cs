using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovHackSeduc.Entity
{
    public class Aula
    {
        public string Nome
        {
            get;
            set;
        }

        public string AulaId
        {
            get;
            set;
        }

        public DateTime DataDeAula
        {
            get;
            set;
        }

        public string Professor
        {
            get;
            set;
        }

        public string AlunoId
        {
            get;
            set;
        }

        public string Turma
        {
            get;
            set;
        }

        public string Escola
        {
            get;
            set;
        }

        public bool Ausente
        {
            get;
            set;
        }

        public AusenciaJustificativaTipo? AusenteJustificativaTipo
        {
            get;
            set;
        }

        public string AusenteJustificativa
        {
            get;
            set;
        }

        public double AulaAvaliacao
        {
            get;
            set;
        }

        public string AulaAvaliacaoComentario
        {
            get;
            set;
        }
    }
}