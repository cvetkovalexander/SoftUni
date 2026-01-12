using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.Problem_06;

[XmlRoot("Users")]
public class ExportUsersWithSoldProductsDto
{
    [XmlElement("User")]
    public ExportUserDto[] Users { get; set; } = null!;
}
