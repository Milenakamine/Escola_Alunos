using EscolaAluno.Contexts;
using EscolaAluno.Domains;
using EscolaAluno.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAluno.Repositories
{
    public class AlunaRepository : IAlunaRepository
    {
        //outro caminho
        private readonly AlunoEscolaContext _ctx;
        public AlunaRepository()
        {
            _ctx = new AlunoEscolaContext();
        }

        //adiciona um aluno
        public void Adicionar(Aluno a)
        {
            try
            {
                //adiciona o objeto no contexto
                _ctx.Alunos.Add(a);
                //salva as alteracoes
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //busca um aluno pelo seu id
        public Aluno BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Alunos.Find(id);
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //busca um aluno por nome
        public List<Aluno> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Alunos.Where(p => p.Nome.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //edita um aluno
        public void Editar(Aluno a)
        {
            try
            {
                //busca pelo id
                Aluno alunoTemp = BuscarPorId(a.Id);
                //verifica se o aluno existe no sistema, caso nao exista gera um exception
                if (alunoTemp == null)
                    throw new Exception("Aluno não encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //caso exista altera suas propriedades
                alunoTemp.Nome = a.Nome;
                alunoTemp.DataNasc = a.DataNasc;

                //altera alunos no seu contexto
                _ctx.Alunos.Update(alunoTemp);
                //salva suas alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Aluno> Listar()
        {
            try
            {
                return _ctx.Alunos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //remove um aluno
        public void Remover(Guid id)
        {
            try
            {
                //busca pelo id
                Aluno alunoTemp = BuscarPorId(id);
                //verifica se o aluno existe no sistema, caso nao exista gera um exception
                if (alunoTemp == null)
                    throw new Exception("Aluno não encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //remove aluno no contexto atual
                _ctx.Alunos.Remove(alunoTemp);
                //salva as alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       
    }
}
