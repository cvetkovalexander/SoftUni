using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static P01_StudentSystem.Common.EntityValidations.Course;

namespace P01_StudentSystem.Data.Models;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [Column(TypeName = PriceColumnType)]
    public decimal Price { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; } 
        = new HashSet<StudentCourse>();

    public virtual ICollection<Resource> Resources { get; set; } 
        = new HashSet<Resource>();

    public virtual ICollection<Homework> Homeworks { get; set; }
        = new HashSet<Homework>();
}
