using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAluno.Domains
{
    public class Aluno : BaseDomain
    {
        public string Nome { get; set; }

        public DateTime DataNasc { get; set; }


    }
}
