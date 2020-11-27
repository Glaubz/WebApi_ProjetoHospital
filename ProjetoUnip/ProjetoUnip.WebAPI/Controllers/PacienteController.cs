using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUnip.Domain.Person;
using ProjetoUnip.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUnip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        public readonly IProjetoUnipRepository _pac;
        public PacienteController(IProjetoUnipRepository pac)
        {
            _pac = pac;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _pac.GetAllPacientesAsync();
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("{funcionarioId}")]
        public async Task<IActionResult> GetById(int funcionarioId)
        {
            try
            {
                var results = await _pac.GetFuncionarioAsyncById(funcionarioId);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("GetFuncionarioByUserId/{usuarioId}")]
        public async Task<IActionResult> GetFuncionarioByUserId(int usuarioId)
        {
            try
            {
                var results = await _pac.GetFuncionarioAsyncByUsuarioId(usuarioId);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("getByName/{nomeFuncionario}")]
        public async Task<IActionResult> GetByName(string nomeFuncionario)
        {
            try
            {
                var results = await _pac.GetAllFuncionariosAsyncByName(nomeFuncionario);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("getByCpf/{cpf}")]
        public async Task<IActionResult> GetCpf(string cpf)
        {
            try
            {
                var results = await _pac.GetAllFuncionariosAsyncByCpf(cpf);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(Paciente model)
        {
            try
            {
                _pac.add(model);
                _pac.add(model.Pessoa.Usuario);

                if (await _pac.SaveChangesAsync())
                {
                    return Created($"/api/paciente/{model.Id}", model);
                }

            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        // PUT api/values
        [HttpPut("{pacienteId}")]
        public async Task<IActionResult> Put(int pacienteId, Paciente model)
        {
            try
            {
                var paciente = await _pac.GetPacienteAsyncById(pacienteId);
                if (paciente == null) return NotFound();

                _pac.update(model);

                if (await _pac.SaveChangesAsync())
                {
                    return Created($"/api/paciente/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        // DELETE api/values
        [HttpDelete("{pacienteId}")]
        public async Task<IActionResult> Delete(int pacienteId)
        {
            try
            {
                var paciente = await _pac.GetPacienteAsyncById(pacienteId);
                if (paciente == null) return NotFound();

                _pac.delete(paciente);

                if (await _pac.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }
    }
}
