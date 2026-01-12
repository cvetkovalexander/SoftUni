using MoviesApp.Data;
using MoviesApp.DTOs.Json;
using MoviesApp.DTOs.Xml;
using MoviesApp.Models;
using MoviesApp.Services.Interfaces;
using MoviesApp.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MoviesApp.Services;

using static Common.EntityValidation.Movie;

public class ImportService : IImportService
{
    private readonly MoviesAppDbContext _context;
    public ImportService(MoviesAppDbContext context)
    {
        this._context = context;
    }

    public async Task<int> ImportFromJsonAsync(string fileName)
    {
        string jsonFileContent = this.ReadDatasetFileContents(fileName);

        ICollection<Movie> moviesToImport = new List<Movie>();
        IEnumerable<ImportJsonMovieDto>? importedMovieDtos = JsonConvert
            .DeserializeObject<ImportJsonMovieDto[]>(jsonFileContent);

        if (importedMovieDtos != null) 
        {
            foreach (ImportJsonMovieDto movieDto in importedMovieDtos) 
            {
                if (!this.IsValid(movieDto))
                    continue;

                bool isReleaseDateValid = DateOnly
                    .TryParseExact(movieDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly releaseDate);

                if (!isReleaseDateValid)
                    continue;

                Movie newMovie = new Movie()
                {
                    Title = movieDto.Title,
                    Genre = movieDto.Genre,
                    ReleaseDate = releaseDate,
                    Director = movieDto.Director,
                    Duration = movieDto.Duration,
                    Description = movieDto.Description,
                    ImageUrl = movieDto.ImageUrl
                };

                moviesToImport.Add(newMovie);
            }

            await this._context.AddRangeAsync(moviesToImport);
            await this._context.SaveChangesAsync();
        }

        return moviesToImport.Count;
    }

    public async Task<int> ImportFromXmlAsync(string fileName)
    {
        /* Using dynamic LINQ-to-XML using XDoc will be more suitable */
        const string xmlRootElement = "MoviesLibrary";
        string xmlFileContent = this.ReadDatasetFileContents(fileName);

        ICollection<Movie> moviesToImport = new List<Movie>();
        IEnumerable<ImportXmlGenreGroupDto>? importedGenreGroupDtos =
            XmlSerializerWrapper.Deserialize<ImportXmlGenreGroupDto[]>(xmlFileContent, xmlRootElement);
        if (importedGenreGroupDtos != null)
        {
            foreach (ImportXmlGenreGroupDto genreGroupDto in importedGenreGroupDtos)
            {
                if (!this.IsValid(genreGroupDto))
                {
                    continue;
                }

                foreach (ImportGenreGroupMovieDto movieDto in genreGroupDto.Movies)
                {
                    if (!this.IsValid(movieDto))
                    {
                        continue;
                    }

                    bool isDurationValid = int
                        .TryParse(movieDto.Duration, out int durationVal);
                    if ((!isDurationValid) ||
                        (durationVal < MovieDurationMinValue) ||
                        (durationVal > MovieDurationMaxValue))
                    {
                        continue;
                    }

                    if (this._context.Movies.Any(m => m.Title == movieDto.Title))
                    {
                        /* Based on assumption that the Movie Title is unique */
                        /* This will prevent double import even if the application is restarted */
                        continue;
                    }

                    /* Optionally add validation of the rating, it is intended to be used */
                    if (!this.ValidateMovieDetails(movieDto.Details, genreGroupDto.Name, out DateOnly releaseDate))
                    {
                        continue;
                    }

                    if ((movieDto.Media != null) &&
                        (!this.IsValid(movieDto.Media)))
                    {
                        continue;
                    }

                    Movie newMovie = new Movie()
                    {
                        Title = movieDto.Title,
                        Genre = movieDto.Details.Genre,
                        ReleaseDate = releaseDate,
                        Director = movieDto.Details.Director,
                        Duration = durationVal,
                        Description = movieDto.Description,
                        ImageUrl = movieDto.Media?.ImageUrl
                    };
                    moviesToImport.Add(newMovie);
                }
            }

            await this._context.Movies.AddRangeAsync(moviesToImport);
            await this._context.SaveChangesAsync();
        }

        return moviesToImport.Count;
    }

    private bool ValidateMovieDetails(ImportMovieDetailsDto movieDetails, string genreGroup, out DateOnly releaseDate)
    {
        bool result = this.IsValid(movieDetails);

        if (movieDetails.Genre != genreGroup)
        {
            result = false;
        }

        bool isReleaseDateValid = DateOnly
            .TryParseExact(movieDetails.Release.Date, "yyyy-MM-dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);
        if (!isReleaseDateValid)
        {
            result = false;
        }

        //releaseDate = releaseDateVal;
        return result;
    }

    private string ReadDatasetFileContents(string fileName) 
    {
        string fileDirPath = Path
            .Combine(Directory.GetCurrentDirectory(), "./Datasets/");

        string fileText = File
            .ReadAllText(fileDirPath + fileName);

        return fileText;
    }

    private bool IsValid(object obj) 
    {
        ValidationContext validationContext = new ValidationContext(obj);
        ICollection<ValidationResult> validationResults
           = new List<ValidationResult>();

        return Validator
            .TryValidateObject(obj, validationContext, validationResults);
    }
}
