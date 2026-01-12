using System.ComponentModel.DataAnnotations;
using static MusicHub.Common.EntityValidation.Writer;

namespace MusicHub.Data.Models;

public class Writer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public string? Pseudonym { get; set; }

    public virtual ICollection<Song> Songs { get; set; }
        = new HashSet<Song>();
}
