namespace API.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Subdivision { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public int PeoplePartnerID { get; set; }
        public int OutOfOfficeBalance { get; set; }
        public string? Photo { get; set;}

        public virtual Employee PeoplePartner { get; set; }

    }
}
