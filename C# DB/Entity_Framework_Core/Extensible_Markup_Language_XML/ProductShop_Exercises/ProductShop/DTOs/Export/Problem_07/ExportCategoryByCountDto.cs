using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.Problem_07;

[XmlType("Category")]
public class ExportCategoryByCountDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("count")]
    public int Count { get; set; }

    [XmlElement("averagePrice")]
    public decimal AveragePrice { get; set; }

    [XmlElement("totalRevenue")]
    public decimal TotalRevenue { get; set; }
}
