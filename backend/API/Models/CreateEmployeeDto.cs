using API.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CreateEmployeeDto
    {
        public required string FullName { get; set; }
        public required string Subdivision { get; set; }
        public EmployeePosition Position { get; set; }
        public EmployeeStatus Status { get; set; }
        public int PeoplePartnerID { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "OutOfOfficeBalance must be greater than or equal to zero.")]
        public int OutOfOfficeBalance { get; set; }

        public string? Photo { get; set; }

    }
}
