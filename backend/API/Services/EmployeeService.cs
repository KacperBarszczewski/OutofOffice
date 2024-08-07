using API.Entities;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IEmployeeService
    {
        EmployeeDto? GetById(int id);
        IEnumerable<EmployeeDto> GetAll();
        int Create(CreateEmployeeDto dto);
        bool Delete(int id);
        bool Update(int id, UpdateEmployeeDto dto);
    }


    public class EmployeeService : IEmployeeService
    {
        private readonly OutOfOfficeDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(OutOfOfficeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public EmployeeDto? GetById(int id)
        {
            var employee = _dbContext.Employees
                .Include(e => e.PeoplePartner)
                .FirstOrDefault(e => e.ID == id);

            if (employee is null) return null;

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;

        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _dbContext.Employees.ToList();

            var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);

            return employeesDto;
        }

        public int Create(CreateEmployeeDto dto)
        {

            var employee = _mapper.Map<Employee>(dto);
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return employee.ID;
        }

        public bool Update(int id, UpdateEmployeeDto dto)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.ID == id);

            if (employee is null) return false;

            employee.Subdivision = dto.Subdivision;
            employee.Position = dto.Position;
            employee.Status = dto.Status;
            employee.PeoplePartnerID = dto.PeoplePartnerID;
            employee.OutOfOfficeBalance = dto.OutOfOfficeBalance;
            employee.Photo = dto.Photo;

            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.ID == id);

            if (employee is null) return false;

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
