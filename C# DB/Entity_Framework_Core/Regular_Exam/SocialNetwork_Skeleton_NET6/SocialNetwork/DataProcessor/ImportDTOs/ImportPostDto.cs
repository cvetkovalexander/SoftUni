namespace SocialNetwork.DataProcessor.ImportDTOs;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

using static SocialNetwork.Common.EntityValidation.Post;

public class ImportPostDto
{
    [Required]
    [MinLength(ContentMinLength)]
    [MaxLength(ContentMaxLength)]
    [JsonProperty("Content")]
    public string Content { get; set; } = null!;

    [Required]
    [JsonProperty("CreatedAt")]
    public string CreatedAt { get; set; } = null!;

    [Required]
    [JsonProperty("CreatorId")]
    public string CreatorId { get; set; } = null!;
}
