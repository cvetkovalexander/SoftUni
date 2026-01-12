using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MusicHub.Common.EntityValidation.Song;

namespace MusicHub.Data.Models;

public class Song
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public TimeSpan Duration { get; set; }

    public DateTime CreatedOn { get; set; }

    public Genre Genre { get; set; }

    [ForeignKey(nameof(Album))]
    public int? AlbumId { get; set; }

    public virtual Album? Album { get; set; }

    [ForeignKey(nameof(Writer))]
    public int WriterId { get; set; }

    public virtual Writer Writer { get; set; } = null!;

    [Column(TypeName = PriceColumnType)]
    public decimal Price { get; set; }

    public virtual ICollection<SongPerformer> SongPerformers { get; set; }
        = new HashSet<SongPerformer>();
}
