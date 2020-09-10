using EscolaAluno.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAluno.Interfaces
{
    public interface IAlunaRepository
    {
        List<Aluno> Listar();
        Aluno BuscarPorId(Guid id);

        List<Aluno> BuscarPorNome(string nome);

        void Adicionar(Aluno a);

        void Editar(Aluno a);

        void Remover(Guid id);

    }
}
