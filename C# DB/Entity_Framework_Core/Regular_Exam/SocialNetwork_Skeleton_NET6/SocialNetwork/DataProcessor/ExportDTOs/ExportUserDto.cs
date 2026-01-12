using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs;

[XmlType("User")]
public class ExportUserDto
{
    [XmlAttribute("Friendships")]
    public string Friendships { get; set; } = null!;

    [XmlElement("Username")]
    public string Username { get; set; } = null!;

    [XmlArray("Posts")]
    public ExportPostDto[] Posts { get; set; } = null!;
}
