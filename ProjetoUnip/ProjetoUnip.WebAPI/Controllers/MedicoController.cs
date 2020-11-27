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
    public class MedicoController : ControllerBase
    {
        public readonly IProjetoUnipRepository _med;
        public MedicoController(IProjetoUnipRepository med)
        {
            _med = med;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _med.GetAllMedicosAsync();
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // GET api/values
        [HttpGet("{medicoId}")]
        public async Task<IActionResult> GetById(int medicoId)
        {
            try
            {
                var results = await _med.GetFuncionarioAsyncById(medicoId);
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
                var results = await _med.GetFuncionarioAsyncByUsuarioId(usuarioId);
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
                var results = await _med.GetAllFuncionariosAsyncByName(nomeFuncionario);
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
                var results = await _med.GetAllFuncionariosAsyncByCpf(cpf);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(Medico model)
        {
            try
            {
                _med.add(model);
                _med.add(model.Pessoa.Usuario);

                if (await _med.SaveChangesAsync())
                {
                    return Created($"/api/medico/{model.Id}", model);
                }

            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        // PUT api/values
        [HttpPut("{medicoId}")]
        public async Task<IActionResult> Put(int medicoId, Medico model)
        {
            try
            {
                var medico = await _med.GetMedicoAsyncById(medicoId);
                if (medico == null) return NotFound();

                _med.update(model);

                if (await _med.SaveChangesAsync())
                {
                    return Created($"/api/medico/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        // DELETE api/values
        [HttpDelete("{medicoId}")]
        public async Task<IActionResult> Delete(int medicoId)
        {
            try
            {
                var medico = await _med.GetMedicoAsyncById(medicoId);
                if (medico == null) return NotFound();

                _med.delete(medico);

                if (await _med.SaveChangesAsync())
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
