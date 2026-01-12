using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.Problem_07;

[XmlRoot("Categories")]
public class ExportCategoriesByProductCountDto
{
    [XmlElement("Category")]
    public ExportCategoryByCountDto[] Categories { get; set; } = null!;
}
