using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.Problem_08;

[XmlType("SoldProducts")]
public class ExportSoldProductsDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    public ExportProductDto[] Products { get; set; } = null!;
}
