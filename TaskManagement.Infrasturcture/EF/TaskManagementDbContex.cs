using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskManagement.Domain.Project;
using TaskManagement.Domain.Task;
using TaskManagement.Domain.User;

namespace TaskManagement.Infrasturcture.EF
{
    public class TaskManagementDbContex : DbContext
    {
        public DbSet<Domain.User.User> Users { get; set; }
        public DbSet<Domain.Task.Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Domain.Project.Project> Projects { get; set; }

        public TaskManagementDbContex(
            DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Task.Task>()
                .HasOne(t => t.Assignee)
                .WithMany()
                .HasForeignKey(t => t.AssigneeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Domain.Task.Task>()
                .HasOne(t => t.Reporter)
                .WithMany()
                .HasForeignKey(t => t.ReporterID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class TaskManagementDbContextFactory : IDesignTimeDbContextFactory<TaskManagementDbContex>
    {
        public TaskManagementDbContex CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskManagementDbContex>();
            optionsBuilder.UseSqlServer("Server=.;Database=TaskManagement;Trusted_Connection=True;TrustServerCertificate=True;");

            return new TaskManagementDbContex(optionsBuilder.Options);
        }
    }

}
