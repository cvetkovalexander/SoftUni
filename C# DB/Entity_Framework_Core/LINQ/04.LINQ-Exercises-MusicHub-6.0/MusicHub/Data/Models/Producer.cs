using System.ComponentModel.DataAnnotations;
using static MusicHub.Common.EntityValidation.Producer;

namespace MusicHub.Data.Models;

public class Producer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public string? Pseudonym { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Album> Albums { get; set; }
        = new HashSet<Album>();
}
