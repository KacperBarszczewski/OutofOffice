using API.Entities;

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
                    var employees = GetEmployees();
                    _dbContext.Employees.AddRange(employees);
                    _dbContext.SaveChanges();
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
