using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test11.Models;
using Test11.Repository;

namespace Test11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public readonly CustomersRepository _repository;
        public readonly string _connectionString;
        public CustomersController(CustomersRepository repository)
        {
            _repository = repository??throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet, Route("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            try
            {
                var result = await this._repository.GetCustomers();
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
        [HttpPost, Route("InsertCustomers")]
        public async Task<ActionResult<Customers>> Post([FromBody] Customers lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }
            var change = await _repository.InsertCustomers(lead);

            if (change != null)
                return Ok(change);
            else
                return BadRequest("Not successfull");
        }
        [HttpPut, Route("UpdateCustomers")]
        public async Task<ActionResult<Data>> Put([FromBody] Customers lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }

            var change = await _repository.UpdateCustomers(lead);

            if (change != null)
                return Ok(change);
            else
                return BadRequest("Not successfull");
        }
    }
}
