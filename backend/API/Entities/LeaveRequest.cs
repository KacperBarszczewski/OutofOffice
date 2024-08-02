namespace API.Entities
{
    public enum AbsenceReason
    {
        Vacation,
        Sickness,
        ChildCare, 
        Training, 
        PersonalMatters
    }

    public class LeaveRequest
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public AbsenceReason AbsenceReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public ApprovalRequestStatus Status { get; set; } = ApprovalRequestStatus.New;

        public virtual Employee? Employee { get; set; }
    }
}
