using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test11.Models;
using Test11.Repository;

namespace Test11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdgesController : ControllerBase
    {
        private readonly EdgesRepository _repository;
        private readonly string _connectionString;
        public EdgesController(EdgesRepository repository)
        {
            _repository = repository ??throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet, Route("GetEdges")]
        public async Task<ActionResult<IEnumerable<Edges>>> GetEdges()
        {
            try
            {
                var result = await this._repository.GetEdges();
                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost, Route("InsertEdges")]
        public async Task<ActionResult<Edges>> Post([FromBody] Edges lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }
            var change = await _repository.InsertEdges(lead);

            if (change != null)
                return Ok(change);
            else
                return BadRequest("Not successfull");
        }
        [HttpPut, Route("UpdateEdges")]
        public async Task<ActionResult<Edges>> Put([FromBody] Edges lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }

            var change = await _repository.UpdateEdges(lead);

            if (change != null)
                return Ok(change);
            else
                return BadRequest("Not successfull");
        }
    }
}
