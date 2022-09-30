using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test11.Context;
using Test11.Models;
using Test11.Repository;

namespace Test11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public readonly DataRepository _repository;
        public readonly string _connectionString;
        public DataController(DataRepository repository)
        {
            _repository = repository?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet, Route("GetAllData")]
        public async Task<ActionResult<IEnumerable<Data>>> GetData()
        {
            try
            {
                var result = await this._repository.GetData();
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
        [HttpPost, Route("InsertData")]
        public async Task<ActionResult<Data>> Post([FromBody] Data lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }
            var change = await _repository.InsertData(lead);

            if (change != null)
                return Ok(change);
            else
                return BadRequest("Not successfull");
        }
        [HttpPut, Route("UpdateData")]
        public async Task<ActionResult<Data>> Put([FromBody] Data lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }

            var change = await _repository.UpdateData(lead);

            if (change != null)
                return Ok(change);
            else
                return BadRequest("Not successfull");
        }

    }
}
