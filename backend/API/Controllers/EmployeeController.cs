using API.Entities;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly OutOfOfficeDbContext _dbContext;

        public EmployeeController(OutOfOfficeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAll()
        {
            var employees = _dbContext.Employees.ToList();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetById([FromRoute] int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}
