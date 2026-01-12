using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.Problem_06;

[XmlType("Product")]
public class ExportSoldProductDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("price")]
    public decimal Price { get; set; }
}
