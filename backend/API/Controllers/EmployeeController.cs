using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public ActionResult CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _employeeService.Create(dto);

            return Created($"api/employee/{id}", null);

        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAll()
        {
            var employeesDto = _employeeService.GetAll();

            return Ok(employeesDto);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetById([FromRoute] int id)
        {
            var employeeDto = _employeeService.GetById(id);

            if (employeeDto == null)
            {
                return NotFound();
            }

            return Ok(employeeDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _employeeService.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _employeeService.Update(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
