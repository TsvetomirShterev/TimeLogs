namespace TimeLogs.DB;

using Microsoft.EntityFrameworkCore;
using TimeLogs.DB.Entities;

public class TimeLogsDbContext : DbContext
{
    public TimeLogsDbContext()
    {

    }

    public TimeLogsDbContext(DbContextOptions<TimeLogsDbContext> options)
    {

    }

    public virtual Project Project { get; set; }
    public virtual TimeLog TimeLog { get; set; }
    public virtual User User { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>(p =>
        {
            p.HasKey(p => p.Id);

            p.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(128);

            modelBuilder.Entity<Project>()
            .HasMany(p => p.TimeLogs)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId);
        });


        modelBuilder.Entity<User>(u =>
        {
            u.HasKey(u => u.Id);

            u.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(128);

            u.Property(u => u.LastName)
           .IsRequired()
           .HasMaxLength(128);

            u.Property(u => u.Email)
           .IsRequired()
           .HasMaxLength(128);

            modelBuilder.Entity<User>()
           .HasMany(u => u.TimeLogs)
           .WithOne(t => t.User)
           .HasForeignKey(t => t.UserId);
        });
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
