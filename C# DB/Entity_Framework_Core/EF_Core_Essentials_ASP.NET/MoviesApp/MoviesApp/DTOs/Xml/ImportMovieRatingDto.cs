using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MoviesApp.DTOs.Xml;

using static Common.EntityValidation.Movie;

[XmlType("Rating")]
public class ImportMovieRatingDto
{
    [XmlAttribute("source")]
    [MaxLength(MovieRatingSourceMaxLength)]
    public string? RatingSource { get; set; }
}
