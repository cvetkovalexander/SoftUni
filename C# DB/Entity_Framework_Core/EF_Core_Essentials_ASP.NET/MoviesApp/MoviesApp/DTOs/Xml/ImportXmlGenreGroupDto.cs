namespace MoviesApp.DTOs.Xml;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.EntityValidation.Movie;

[XmlType("GenreGroup")]
public class ImportXmlGenreGroupDto
{
    [XmlAttribute("name")]
    [Required]
    [MinLength(MovieGenreMinLength)]
    [MaxLength(MovieGenreMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement("Movie")]
    public ImportGenreGroupMovieDto[] Movies { get; set; } = null!;
}
