
using EscolaAluno.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAluno.Contexts
{
    public class AlunoEscolaContext : DbContext
    {

        public DbSet<AlunosEscola> EscolaAlunos { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=LAB107401\SQLEXPRESS;Initial Catalog=Db_Senai_Escola_Tarde_Dev;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
