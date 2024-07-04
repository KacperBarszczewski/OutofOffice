using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    public class OutOfOfficeDbContext: DbContext
    {
        private string _connectionString = "Server=MSSQL,1433;Database=OutOfOfficeDb;User Id=sa;Password=Admin123!;TrustServerCertificate=True;";
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.PeoplePartner)
                .WithMany()
                .HasForeignKey(e => e.PeoplePartnerID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApprovalRequest>()
                .HasOne(ar => ar.LeaveRequest) 
                .WithMany() 
                .HasForeignKey(ar => ar.LeaveRequestID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
