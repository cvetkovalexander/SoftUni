using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.DTOs.Json;

using static Common.EntityValidation.Movie;

public class ImportJsonMovieDto
{
    [Required]
    [MaxLength(MovieTitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(MovieGenreMaxLength)]
    public string Genre { get; set; } = null!;

    [Required]
    public string ReleaseDate { get; set; } = null!;

    [Required]
    [MaxLength(MovieDirectorMaxLength)]
    public string Director { get; set; } = null!;

    public int Duration { get; set; }

    [Required]
    [MaxLength(MovieDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [MaxLength(MovieImageUrlMaxLength)]
    public string? ImageUrl { get; set; }
}
