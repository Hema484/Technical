using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test11.Models;
using Test11.Repository;

namespace Test11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly NodeRepository _repository;
        private readonly string _connectionString;
        public NodeController(NodeRepository repository)
        {
            _repository=repository?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet, Route("GetNode")]
        public async Task<ActionResult<IEnumerable<Node>>> GetNode()
        {
            try
            {
                var result = await this._repository.GetNode();
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
        [HttpPost, Route("InsertNode")]
        public async Task<ActionResult<Node>> Post([FromBody] Node lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }
            var change = await _repository.InsertNode(lead);

            if (change != null)
                return Ok(change);
            else
                return BadRequest("Not successfull");
        }
        [HttpPut, Route("UpdateNode")]
        public async Task<ActionResult<Node>> Put([FromBody] Node lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }

            var change = await _repository.UpdateNode(lead);

            if (change != null)
                return Ok(change);
            else
                return BadRequest("Not successfull");
        }

    }
}
