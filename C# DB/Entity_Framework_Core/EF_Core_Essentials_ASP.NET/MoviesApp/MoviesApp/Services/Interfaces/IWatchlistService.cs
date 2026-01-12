using MoviesApp.ViewModels.Movies;

namespace MoviesApp.Services.Interfaces;

public interface IWatchlistService
{
    Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesInWatchlistAsync();

    Task<bool> AddMovieToWatchlistAsync(int movieId);

    Task RemoveAsync(int movieId);

    Task<bool> MovieExists(int movieId);
}
