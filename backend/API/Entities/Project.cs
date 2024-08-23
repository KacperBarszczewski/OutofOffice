namespace API.Entities
{
    public enum ProjectType
    {
        Internal,
        External,
        Research,
        Development,
        Maintenance,
        Support
    }

    public enum ProjectStatus
    {
        Active,
        Inactive
    }
    public class Project
    {
        public int ID { get; set; }
        public ProjectType ProjectType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ProjectManagerID { get; set; }
        public string? Comment { get; set; }
        public ProjectStatus Status { get; set; }

        public virtual Employee? ProjectManager { get; set; }
    }
}
