using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.Problem_19;

[XmlRoot("Sales")]
public class ExportSalesWithDiscountDto
{
    [XmlElement("sale")]
    public ExportSaleDto[] Sales { get; set; } = null!;
}
