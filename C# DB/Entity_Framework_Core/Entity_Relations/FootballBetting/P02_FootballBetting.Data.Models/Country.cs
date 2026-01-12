using System.ComponentModel.DataAnnotations;
using static P02_FootballBetting.Common.EntityValidation.Country;

namespace P02_FootballBetting.Data.Models;

public class Country
{
    [Key]
    public int CountryId { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Town> Towns { get; set; }
        = new HashSet<Town>();
}
