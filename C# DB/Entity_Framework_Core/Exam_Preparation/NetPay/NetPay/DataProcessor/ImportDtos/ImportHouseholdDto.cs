using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static NetPay.Common.EntityValidation.Household;

namespace NetPay.DataProcessor.ImportDtos;

[XmlType("Household")]
public class ImportHouseholdDto
{
    [Required]
    [MinLength(PhoneNumberLength)]
    [MaxLength(PhoneNumberLength)]
    [RegularExpression(PhoneNumberRegExPattern)]
    [XmlAttribute("phone")]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [MinLength(ContactPersonMinLength)]
    [MaxLength(ContactPersonMaxLength)]
    [XmlElement("ContactPerson")]
    public string ContactPerson { get; set; } = null!;

    [MinLength(EmailMinLength)]
    [MaxLength(EmailMaxLength)]
    [XmlElement("Email")]
    public string? Email { get; set; }
}
