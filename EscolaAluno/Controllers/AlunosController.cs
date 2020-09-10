using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAluno.Domains;
using EscolaAluno.Interfaces;
using EscolaAluno.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunaRepository alunaRepository;

        public AlunosController()
        {
            alunaRepository = new AlunaRepository();
        }

        [HttpGet]
        public List<Aluno> Get()
        {
            return alunaRepository.Listar();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Aluno Get(Guid id)
        {
            return alunaRepository.BuscarPorId(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public void Post(Aluno a)
        {
           alunaRepository.Adicionar(a);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Aluno a)
        {
            a.Id = id;
            alunaRepository.Editar(a);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            alunaRepository.Remover(id);
        }
    }
}
