namespace API.Entities
{
    public enum EmployeePosition
    {
        Employee,
        HRManager,
        ProjectManager,
        Administrator
    }

    public enum EmployeeStatus
    {
        Active,
        Inactive
    }

    public class Employee
    {
        public int ID { get; set; }
        public required string FullName { get; set; }
        public required string Subdivision { get; set; }
        public EmployeePosition Position { get; set; }
        public EmployeeStatus Status { get; set; }
        public int PeoplePartnerID { get; set; }
        public int OutOfOfficeBalance { get; set; }
        public string? Photo { get; set; }

        public virtual Employee? PeoplePartner { get; set; }

    }
}
