using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static SocialNetwork.Common.EntityValidation.Message;

namespace SocialNetwork.DataProcessor.ImportDTOs;

[XmlType("Message")]
public class ImportMessageDto
{
    [Required]
    [XmlAttribute("SentAt")]
    public string SentAt { get; set; } = null!;

    [Required]
    [MinLength(ContentMinLength)]
    [MaxLength(ContentMaxLength)]
    [XmlElement("Content")]
    public string Content { get; set; } = null!;

    [Required]
    [XmlElement("Status")]
    public string Status { get; set; } = null!;

    [Required]
    [XmlElement("ConversationId")]
    public string ConversationId { get; set; } = null!;

    [Required]
    [XmlElement("SenderId")]
    public string SenderId { get; set; } = null!;
}
