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



        /// <summary>
        /// Mostra todos os alunos cadastrado 
        /// </summary>
        /// <returns>Lista com todos os alunos</returns>
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

                //caso exista retorno Ok e o total de alunos cadastrados
                return Ok(new
                {
                    totalCount = alunos.Count,
                    data = alunos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // GET api/<AlunoController>/5
        /// <summary>
        /// Mostra um único aluno
        /// </summary>
        /// <param name="id">ID do aluno</param>
        /// <returns>Um aluno</returns>
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
        /// <summary>
        /// Cadastra um novo aluno
        /// </summary>
        /// <param name="a">Objeto completo de Aluno</param>
        /// <returns>Aluno cadastrado</returns>
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
        /// <summary>
        /// Altera determinado aluno
        /// </summary>
        /// <param name="id">ID do aluno</param>
        /// <param name="a">Objeto Aluno com as alterações</param>
        /// <returns>Info do aluno alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Aluno a)
        {
            try
            {  
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
        /// <summary>
        /// Exclui um aluno
        /// </summary>
        /// <param name="id">ID do aluno</param>
        /// <returns>ID excluído</returns>
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
