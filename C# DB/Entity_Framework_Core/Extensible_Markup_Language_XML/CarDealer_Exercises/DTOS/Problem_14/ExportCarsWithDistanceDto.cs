using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.Problem_14;

[XmlRoot("cars")]
public class ExportCarsWithDistanceDto
{
    [XmlElement("car")]
    public ExportCarDto[] Cars { get; set; } = null!;
}
