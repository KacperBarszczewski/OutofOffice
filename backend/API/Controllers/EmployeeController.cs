using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/employee")]
    [ApiController]
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

            return Ok(employeeDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _employeeService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateEmployeeDto dto)
        {
            _employeeService.Update(id, dto);

            return Ok();
        }
    }
}
