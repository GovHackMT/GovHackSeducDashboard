using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovHackSeduc.Entity
{
    public class Aluno
    {
        public string AlunoId
        {
            get;
            set;
        }

        public string Nome
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

        public int Matricula
        {
            get;
            set;
        }
    }
}