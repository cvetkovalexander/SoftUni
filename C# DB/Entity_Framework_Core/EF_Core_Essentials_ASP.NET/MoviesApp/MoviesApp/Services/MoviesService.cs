using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.Services.Interfaces;
using MoviesApp.ViewModels.Movies;
using System.Globalization;

namespace MoviesApp.Services;

public class MoviesService : IMoviesService
{
    private const string DefaultImageUrl =
        "https://img.freepik.com/free-vector/cinema-film-production-realistic-transparent-composition-with-isolated-image-clapper-with-empty-fields-vector-illustration_1284-66163.jpg?semt=ais_incoming&w=740&q=80";

    private readonly MoviesAppDbContext _context;

    public MoviesService(MoviesAppDbContext context)
    {
        this._context = context;
    }

    public async Task CreateAsync(AddMovieFormModel inputModel)
    {
        Movie newMovie = new Movie()
        {
            Title = inputModel.Title,
            Genre = inputModel.Genre,
            ReleaseDate = DateOnly.FromDateTime(inputModel.ReleaseDate),
            Director = inputModel.Director,
            Duration = inputModel.Duration,
            Description = inputModel.Description,
            ImageUrl = string.IsNullOrWhiteSpace(inputModel.ImageUrl)
                ? DefaultImageUrl
                : inputModel.ImageUrl
        };

        await this._context.Movies.AddAsync(newMovie);
        await this._context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Movie? movieToDelete = await this._context
            .Movies
            .FindAsync(id);

        if (movieToDelete == null)
            return false;

        // The Watchlist-Movie relationship is configured with Cascade Delete
        // => All Watchlist entries referencing this movie will be deleted automatically
        this._context.Movies.Remove(movieToDelete!);
        await this._context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        bool movieExists = await this._context
            .Movies
            .AnyAsync(m => m.Id == id);

        return movieExists;
    }

    public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesListAsync()
    {
        IEnumerable<AllMoviesIndexViewModel> allMoviesIndex = await this._context
            .Movies
            .AsNoTracking()
            .Select(m => new AllMoviesIndexViewModel()
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                ReleaseDate = m.ReleaseDate.ToString(DateTimeFormatInfo.CurrentInfo),
                Director = m.Director,
                Duration = m.Duration,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
            })
            .ToArrayAsync();

        return allMoviesIndex;
    }

    public async Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(int id)
    {
        MovieDetailsViewModel? viewModel = null;
        Movie? movie = await this._context.Movies.FindAsync(id);

        if (movie != null)
        {
            viewModel = new MovieDetailsViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Director = movie.Director,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate.ToDateTime(TimeOnly.MinValue),
                Description = movie.Description,
                ImageUrl = movie.ImageUrl
            };
        }

        return viewModel;
    }

    public async Task<AllMoviesIndexViewModel?> PrepareMovieViewModelForDeleteAsync(int id)
    {
        AllMoviesIndexViewModel viewModel = null;
        Movie? movie = await this._context.Movies.FindAsync(id);

        if (movie != null)
        {
            viewModel = new AllMoviesIndexViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate.ToString(DateTimeFormatInfo.CurrentInfo),
                Director = movie.Director,
                Duration = movie.Duration,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl
            };
        }

        return viewModel;
    }
}
