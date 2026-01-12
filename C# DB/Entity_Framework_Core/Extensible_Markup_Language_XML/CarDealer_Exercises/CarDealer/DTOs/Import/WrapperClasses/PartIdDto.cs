using System.Xml.Serialization;

namespace CarDealer.DTOs.Import.WrapperClasses;

public class PartIdDto
{
    [XmlAttribute("id")]
    public int Id { get; set; }
}
