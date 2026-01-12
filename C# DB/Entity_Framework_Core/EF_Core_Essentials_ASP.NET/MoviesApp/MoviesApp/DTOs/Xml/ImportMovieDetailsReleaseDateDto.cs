using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MoviesApp.DTOs.Xml;

using static Common.EntityValidation.Movie;

[XmlType("Release")]
public class ImportMovieDetailsReleaseDateDto
{
    [XmlAttribute("date")]
    [Required]
    [RegularExpression(MovieReleaseDateRegExprPattern)]
    public string Date { get; set; } = null!;
}
