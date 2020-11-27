using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUnip.Domain.Util;
using ProjetoUnip.Repository;
using System.Threading.Tasks;

namespace ProjetoUnip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoConsultaController : ControllerBase
    {
        public readonly IProjetoUnipRepository _medCons;
        public MedicoConsultaController(IProjetoUnipRepository medCons)
        {
            _medCons = medCons;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _medCons.GetAllMedicosConsultasAsync();
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
        }

        [HttpGet("{medicoConsultaId}")]
        public async Task<IActionResult> Get(int medConsultaId)
        {
            try
            {
                var results = await _medCons.GetMedicoConsultaAsyncById(medConsultaId);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
                throw ex;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(MedicoConsulta model)
        {
            try
            {
                _medCons.add(model);

                if (await _medCons.SaveChangesAsync())
                {
                    return Created($"/api/medicoConsulta/{model.Id}", model);
                }

            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Consulta model)
        {
            try
            {
                _medCons.add(model);

                if (await _medCons.SaveChangesAsync())
                {
                    return Created($"/api/medicoConsulta/{model.Id}", model);
                }

            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        // PUT api/values
        [HttpPut("{medicoConsultaId}")]
        public async Task<IActionResult> Put(int medicoConsultaId, MedicoConsulta model)
        {
            try
            {
                var medicoConsulta = await _medCons.GetMedicoConsultaAsyncById(medicoConsultaId);
                if (medicoConsulta == null) return NotFound();

                _medCons.update(model);

                if (await _medCons.SaveChangesAsync())
                {
                    return Created($"/api/medicoConsulta/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        // DELETE api/values
        [HttpDelete("{medicoConsultaId}")]
        public async Task<IActionResult> Delete(int medicoConsultaId)
        {
            try
            {
                var funcionario = await _medCons.GetMedicoConsultaAsyncById(medicoConsultaId);
                if (funcionario == null) return NotFound();

                _medCons.delete(funcionario);

                if (await _medCons.SaveChangesAsync())
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
