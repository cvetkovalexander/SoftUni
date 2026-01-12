using Microsoft.EntityFrameworkCore;
using AcademicRecordsApp.Data.Models;

namespace AcademicRecordsApp.Data;

public partial class AcademicRecordsDbContext : DbContext
{
    public AcademicRecordsDbContext()
    {
    }

    public AcademicRecordsDbContext(DbContextOptions<AcademicRecordsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exam> Exams { get; set; } = null!;

    public virtual DbSet<Grade> Grades { get; set; } = null!;

    public virtual DbSet<Student> Students { get; set; } = null!;

    public virtual DbSet<Course> Courses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder
                .UseSqlServer(Configuration.GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exam>(entity =>
        {
            entity
                .HasKey(e => e.Id)
                .HasName("PK__Exams__3214EC0748D8054E");

            entity
                .Property(e => e.Name)
                .HasMaxLength(100);

            entity
                .HasOne(c => c.Course)
                .WithMany(e => e.Exams)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC07E81FE40A");

            entity.Property(e => e.Value).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.Exam).WithMany(p => p.Grades)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Exams");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Students");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.Title)
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .HasKey(e => e.Id)
                .HasName("PK__Students__3214EC07E1CA013B");

            entity
                .Property(e => e.FullName)
                .HasMaxLength(100);

            entity
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<Dictionary<string, object>>
                (
                    "StudentsCourses",
                    r => r
                            .HasOne<Course>()
                            .WithMany()
                            .HasForeignKey("CourseId")
                            .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l
                            .HasOne<Student>()
                            .WithMany()
                            .HasForeignKey("StudentId")
                            .OnDelete(DeleteBehavior.ClientSetNull),
                    me =>
                        {
                            me.HasKey("StudentId", "CourseId");
                            me.ToTable("StudentsCourses");
                        }
                );
                    
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
