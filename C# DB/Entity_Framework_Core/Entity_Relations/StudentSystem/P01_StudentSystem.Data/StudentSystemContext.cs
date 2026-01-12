using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using static P01_StudentSystem.Common.ApplicationConstants;

namespace P01_StudentSystem.Data;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {
        
    }

    public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<Student> Students { get; set; } = null!;

    public virtual DbSet<Course> Courses { get; set; } = null!;

    public virtual DbSet<Resource> Resources { get; set; } = null!;

    public virtual DbSet<Homework> Homeworks { get; set; } = null!;

    public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder
                .UseSqlServer(ConnectionString);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<StudentCourse>(e =>
        {
            e.HasKey(sc => new { sc.StudentId, sc.CourseId });
        });

        base.OnModelCreating(builder);
    }
}
