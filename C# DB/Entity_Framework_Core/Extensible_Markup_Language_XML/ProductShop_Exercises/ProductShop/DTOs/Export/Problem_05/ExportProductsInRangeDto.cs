using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.Problem05;

[XmlRoot("Products")]
public class ExportProductsInRangeDto
{
    [XmlElement("Product")]
    public ExportProductDto[] Products { get; set; } = null!;
}
