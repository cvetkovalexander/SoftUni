using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.Problem_17;

[XmlRoot("cars")]
public class ExportCarsWithPartsDto
{
    [XmlElement("car")]
    public ExportCarWithPartsDto[] Cars { get; set; } = null!;
}
