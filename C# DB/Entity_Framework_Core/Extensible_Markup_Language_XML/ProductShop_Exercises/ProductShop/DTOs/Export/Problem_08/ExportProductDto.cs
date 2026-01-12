using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.Problem_08;

[XmlType("Product")]
public class ExportProductDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("price")]
    public decimal Price { get; set; }
}
