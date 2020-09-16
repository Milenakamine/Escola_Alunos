﻿using System;
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
    public class EscolasController : ControllerBase
    {
        private readonly IEscolaRepository escolaRepository;

        public EscolasController()
        {
            escolaRepository = new EscolaRepository();
        }

        /// <summary>
        /// Cadastra uma escola
        /// </summary>
        /// <param name="alunosEscolas"></param>
        /// <returns>Escola cadastrada</returns>
        [HttpPost]
        public IActionResult Post(List<AlunosEscola> alunosEscolas)
        {
            try
            {
                Escola escola = escolaRepository.Adicionar(alunosEscolas);
                return Ok(escola);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Mostra todas as escolas cadastradas
        /// </summary>
        /// <returns>Lista com todas as escolas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var escolas = escolaRepository.Listar();

                if (escolas.Count == 0)
                    return NoContent();

                return Ok(escolas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Mostra uma única escola
        /// </summary>
        /// <returns>Uma escola</returns>

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var escola = escolaRepository.BuscarPorId(id);

                if (escola == null)
                    return NotFound();

                return Ok(escola);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
