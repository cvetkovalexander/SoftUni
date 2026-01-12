using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using static P02_FootballBetting.Common.EntityValidation.Bet;

namespace P02_FootballBetting.Data.Models;

public class Bet
{
    [Key]
    public int BetId { get; set; }

    [Column(TypeName = AmountColumnType)]
    public decimal Amount { get; set; }

    [Required]
    [MaxLength(PredictionMaxLength)]
    public string Prediction { get; set; } = null!;

    public DateTime DateTime { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(Game))]
    public int GameId { get; set; }

    public virtual Game Game { get; set; } = null!;
}
