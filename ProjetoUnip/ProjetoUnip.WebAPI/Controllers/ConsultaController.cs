using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUnip.Domain.Util;
using ProjetoUnip.Repository;
using System.Threading.Tasks;

namespace ProjetoUnip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        public readonly IProjetoUnipRepository _cons;
        public ConsultaController(IProjetoUnipRepository cons)
        {
            _cons = cons;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _cons.GetAllConsultasAsync();
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }
        }

        [HttpGet("{consultaId}")]
        public async Task<IActionResult> Get(int consultaId)
        {
            try
            {
                var results = await _cons.GetConsultaAsyncById(consultaId);
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
        public async Task<IActionResult> Post(Consulta model)
        {
            try
            {
                _cons.add(model);

                if (await _cons.SaveChangesAsync())
                {
                    return Created($"/api/consulta/{model.Id}", model);
                }

            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        // PUT api/values
        [HttpPut("{consultaId}")]
        public async Task<IActionResult> Put(int consultaId, Consulta model)
        {
            try
            {
                var consulta = await _cons.GetConsultaAsyncById(consultaId);
                if (consulta == null) return NotFound();

                _cons.update(model);

                if (await _cons.SaveChangesAsync())
                {
                    return Created($"/api/consulta/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de dados");
            }

            return BadRequest();
        }

        // DELETE api/values
        [HttpDelete("{consultaId}")]
        public async Task<IActionResult> Delete(int consultaId)
        {
            try
            {
                var consulta = await _cons.GetConsultaAsyncById(consultaId);
                if (consulta == null) return NotFound();

                _cons.delete(consulta);

                if (await _cons.SaveChangesAsync())
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
