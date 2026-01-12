using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.Problem_18;

[XmlType("customer")]
public class ExportCustomerDto
{
    [XmlAttribute("full-name")]
    public string FullName { get; set; } = null!;

    [XmlAttribute("bought-cars")]
    public int BoughtCars { get; set; }

    [XmlIgnore]
    public decimal Discount { get; set; }

    [XmlAttribute("spent-money")]
    public decimal SpentMoney { get; set; }
}
