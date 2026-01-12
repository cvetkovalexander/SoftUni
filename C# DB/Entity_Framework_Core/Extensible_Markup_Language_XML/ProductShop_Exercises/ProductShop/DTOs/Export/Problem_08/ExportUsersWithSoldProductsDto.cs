using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.Problem_08;

[XmlRoot("Users")]
public class ExportUsersWithSoldProductsDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public ExportUserDto[] Users { get; set; } = null!;
}
