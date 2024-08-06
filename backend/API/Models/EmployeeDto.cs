using API.Entities;

namespace API.Models
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        public required string FullName { get; set; }
        public required string Subdivision { get; set; }
        public EmployeePosition Position { get; set; }
        public EmployeeStatus Status { get; set; }
        public int OutOfOfficeBalance { get; set; }
        public string? Photo { get; set; }

        public PeoplePartnerDto? PeoplePartner { get; set; }
    }

    public class PeoplePartnerDto
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public required string Subdivision { get; set; }
        public EmployeePosition Position { get; set; }
        public EmployeeStatus Status { get; set; }
        public string? Photo { get; set; }
    }
}
