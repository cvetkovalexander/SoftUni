using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static P01_StudentSystem.Common.EntityValidations.Student;

namespace P01_StudentSystem.Data.Models;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    [Column(TypeName = PhoneNumberColumnType)]
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; } 
        = new HashSet<StudentCourse>();

    public virtual ICollection<Homework> Homeworks { get; set; } 
        = new HashSet<Homework>();
}
