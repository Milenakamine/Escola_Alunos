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
        public IActionResult Get()
        {
            try
            {
                //lista de alunos
                var alunos = alunaRepository.Listar();

                //verifica se existe no conxtexto atual
                //caso nao exista ele retorna NoContext
                if (alunos.Count == 0)
                    return NoContent();

                //se existir retorno vai passar o Ok e os alunos cadastrados
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            { 
                //busca aluno por id
                Aluno a = alunaRepository.BuscarPorId(id);

                //faz a verificacao no contexto para ver se o aluno foi encontrado 
                //caso nao for encontrado o sistema retornara NotFound 
                if (a == null)
                    return NotFound();

                //se existir retorno vai passar o Ok e os dados dos alunos 
                return Ok(a);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }




        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Aluno a)
        {
            try
            {
                //adiciona um novo aluno
                alunaRepository.Adicionar(a);

                //retorna Ok se o aluno tiver sido cadastrado
                return Ok(a);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }





        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Aluno a)
        {
            try
            {  //define o id do aluno
                a.Id = id;
                //edita o aluno
                alunaRepository.Editar(a);

                //retorna o Ok com os dados do aluno
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca o aluno pelo Id
                var a = alunaRepository.BuscarPorId(id);

                //verifica se o aluno existe
                //caso não exista retorna NotFound
                if (a == null)
                    return NotFound();

                //caso exista remove o aluno
                alunaRepository.Remover(id);
                //retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
