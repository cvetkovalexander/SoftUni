using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.Problem_18;

[XmlRoot("customers")]
public class ExportCustomerTotalSalesDto
{
    [XmlElement("customer")]
    public ExportCustomerDto[] Customers { get; set; } = null!;
}
