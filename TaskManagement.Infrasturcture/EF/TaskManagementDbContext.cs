using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskManagement.Domain.Task;

namespace TaskManagement.Infrasturcture.EF
{
    public class TaskManagementDbContext : DbContext
    {
        public DbSet<Domain.User.User> Users { get; set; }
        public DbSet<Domain.Task.Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Domain.Project.Project> Projects { get; set; }

        public TaskManagementDbContext(
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

            modelBuilder.Entity<Domain.Task.Task>()
                .Property(x => x.LastModifiedTime)
                .IsRequired(false);
        }
    }

    public class TaskManagementDbContextFactory : IDesignTimeDbContextFactory<TaskManagementDbContext>
    {
        public TaskManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskManagementDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=TaskManagement;Trusted_Connection=True;TrustServerCertificate=True;");

            return new TaskManagementDbContext(optionsBuilder.Options);
        }
    }

}
