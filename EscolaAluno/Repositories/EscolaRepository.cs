using EscolaAluno.Domains;
using EscolaAluno.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAluno.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EscolaAluno.Repositories
{
    public class EscolaRepository : IEscolaRepository
    {
        private readonly AlunoEscolaContext _ctx;

        public EscolaRepository()
        {
            _ctx = new AlunoEscolaContext();
        }
        
        public Escola Adicionar(List<AlunosEscola> alunosEscolas)
        {
            try
            {
                //criacao do objeto ja passando os valores
                Escola escola = new Escola
                {
                 Nome = "Sesi",
                 
                };
                
                foreach (var item in alunosEscolas)
                {
                    //adiciona um alunoescola a lista
                    escola.AlunosEscolas.Add(new AlunosEscola
                    {
                        
                        IdEscola = escola.Id,
                        IdAluno = item.IdAluno

                    });
                }
                _ctx.Escolas.Add(escola);
                _ctx.SaveChanges();

                return escola;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public Escola BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Escolas
                    .Include(c => c.AlunosEscolas)
                    .ThenInclude(c => c.Aluno)
                    .FirstOrDefault(p => p.Id == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Escola> Listar()
        {
            try
            {
                return _ctx.Escolas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
