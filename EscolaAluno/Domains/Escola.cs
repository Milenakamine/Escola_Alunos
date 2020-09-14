using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAluno.Domains
{
    public class Escola : BaseDomain
    {
        public string Nome { get; set; }

        //relacionamento de 1,N
        public List<AlunosEscola> AlunosEscolas { get; set; }

        public Escola()
        {
            AlunosEscolas = new List<AlunosEscola>();
        }
    }
}
