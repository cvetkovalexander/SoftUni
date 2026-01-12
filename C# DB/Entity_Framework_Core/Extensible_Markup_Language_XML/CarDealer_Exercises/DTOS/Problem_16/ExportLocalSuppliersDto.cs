using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.Problem_16;

[XmlRoot("suppliers")]
public class ExportLocalSuppliersDto
{
    [XmlElement("supplier")]
    public ExportLocalSupplierDto[] Suppliers { get; set; } = null!;
}
