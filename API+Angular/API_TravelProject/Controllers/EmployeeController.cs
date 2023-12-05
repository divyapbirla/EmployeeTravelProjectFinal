using API_TravelProject.Models;
using API_TravelRequest.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace API_TravelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<MovieController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            IEnumerable<Employee> lstemp = await _repository.GetEmployees();
            if (lstemp != null)
            {
                return Ok(lstemp);
            }
            return BadRequest();

        }
        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            Employee emp=await _repository.GetEmployeeById(id);
            //IEnumerable<Employee> lstemp = await _repository.GetEmployees();
            if (emp != null)
            {
                return Ok(emp);
            }
            return BadRequest();
        }



        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            await _repository.CreateEmployee( emp);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = emp.EmployeeID }, emp);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            Employee? emp = await _repository.GetEmployeeById(id);
            if (emp != null)
            {
                _repository.DeleteEmployee(id);
                //await _repository.DeleteEmployee(id);
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(int id, [FromBody] Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            await _repository.UpdateEmployee(emp, id);
            return Ok(emp);
        }

        



    }
}
