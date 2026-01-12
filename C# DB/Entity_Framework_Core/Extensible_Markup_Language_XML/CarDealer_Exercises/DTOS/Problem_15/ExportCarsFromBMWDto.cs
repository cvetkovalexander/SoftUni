using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.Problem_15;

[XmlRoot("cars")]
public class ExportCarsFromBMWDto
{
    [XmlElement("car")]
    public ExportBMWCarDto[] Cars { get; set; } = null!;
}
