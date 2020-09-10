using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAluno.Domains
{
    public class AlunosEscola : BaseDomain
    {
     

        public Guid IdAluno { get; set; }
        [ForeignKey("IdAluno")]
        public Aluno Aluno { get; set; }

        public Guid IdEscola { get; set; }
        [ForeignKey("IdEscola")]
        public Escola Escola { get; set; }

      


    }
}
