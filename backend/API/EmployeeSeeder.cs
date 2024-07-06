using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class EmployeeSeeder
    {
        private readonly OutOfOfficeDbContext _dbContext;

        public EmployeeSeeder(OutOfOfficeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            Console.WriteLine("CanConnsct: "+ _dbContext.Database.CanConnect());
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Employees.Any())
                {
                    _dbContext.Database.ExecuteSqlRaw("ALTER TABLE Employees NOCHECK CONSTRAINT ALL");

                    var employees = GetEmployees();
                    _dbContext.Employees.AddRange(employees);
                    _dbContext.SaveChanges();

                    _dbContext.Database.ExecuteSqlRaw("ALTER TABLE Employees CHECK CONSTRAINT ALL");
                }
            }
        }

        private IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    FullName = "Admin",
                    Subdivision = "Admin",
                    Position = "Admin",
                    Status = "Active",
                    PeoplePartnerID = 0,
                    OutOfOfficeBalance = 0,
                }
            };
            return employees;
        }
    }
}
