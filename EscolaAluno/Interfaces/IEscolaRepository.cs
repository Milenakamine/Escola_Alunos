using EscolaAluno.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAluno.Interfaces
{
    public interface IEscolaRepository
    {
        List<Escola> Listar();

        Escola BuscarPorId(Guid id);

        Escola Adicionar(List<AlunosEscola> alunosEscolas);

    }
}
