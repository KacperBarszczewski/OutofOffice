namespace API.Entities
{
    public enum ApprovalRequestStatus
    {
        New,
        Approved,
        Rejected
    }
    public class ApprovalRequest
    {
        public int ID { get; set; }
        public int ApproverID { get; set; }
        public int LeaveRequestID { get; set; }
        public ApprovalRequestStatus Status { get; set; }
        public string? Comment { get; set; }

        public virtual Employee? Approver { get; set; }
        public virtual LeaveRequest? LeaveRequest { get; set; }
    }
}
