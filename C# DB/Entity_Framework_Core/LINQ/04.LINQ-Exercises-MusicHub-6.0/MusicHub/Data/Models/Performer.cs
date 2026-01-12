using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MusicHub.Common.EntityValidation.Performer;

namespace MusicHub.Data.Models;

public class Performer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(NameMaxLength)]
    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    [Column(TypeName = NetWorthColumnType)]
    public decimal NetWorth { get; set; }

    public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
        = new HashSet<SongPerformer>();
}
