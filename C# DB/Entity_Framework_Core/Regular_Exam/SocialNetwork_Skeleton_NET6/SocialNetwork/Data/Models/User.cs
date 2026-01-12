using System.ComponentModel.DataAnnotations;

using static SocialNetwork.Common.EntityValidation.User;

namespace SocialNetwork.Data.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(UsernameMaxLength)]
    public string Username { get; set; } = null!;

    [Required]
    [MaxLength(EmailMaxLength)]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; }
        = new HashSet<Post>();

    public virtual ICollection<Message> Messages { get; set; }
        = new HashSet<Message>();

    public virtual ICollection<UserConversation> UsersConversations { get; set; }
        = new HashSet<UserConversation>();
}
