using API.Entities;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly OutOfOfficeDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeController(OutOfOfficeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAll()
        {
            var employees = _dbContext.Employees.ToList();

            var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);

            return Ok(employeesDto);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetById([FromRoute] int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return Ok(employeeDto);
        }
    }
}
