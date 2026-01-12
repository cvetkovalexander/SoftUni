using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.Services.Interfaces;
using MoviesApp.ViewModels.Movies;
using System.Globalization;

namespace MoviesApp.Services;

public class WatchlistService : IWatchlistService
{
    private readonly MoviesAppDbContext _context;

    public WatchlistService(MoviesAppDbContext context)
    {
        this._context = context;
    }

    public async Task<bool> AddMovieToWatchlistAsync(int movieId)
    {
        bool movieExists = await this._context
            .Movies
            .AnyAsync(m => m.Id == movieId);

        if (!movieExists)
            return false;

        bool movieExistsInWatchlist = await this._context
            .Watchlists
            .AnyAsync(w => w.MovieId == movieId);

        if (movieExistsInWatchlist)
            return false;

        Watchlist newWatchlist = new Watchlist() 
        {
            MovieId = movieId
        };

        await this._context.Watchlists.AddAsync(newWatchlist);
        await this._context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesInWatchlistAsync()
    {
        IEnumerable<AllMoviesIndexViewModel> allMoviesInWatchlists = await this._context
            .Watchlists
            .Include(w => w.Movie)
            .AsNoTracking()
            .Select(w => w.Movie)
            .Select(m => new AllMoviesIndexViewModel() 
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                ReleaseDate = m.ReleaseDate.ToString(DateTimeFormatInfo.CurrentInfo),
                Director = m.Director,
                Duration = m.Duration,
                Description = m.Description,
                ImageUrl = m.ImageUrl
            })
            .ToArrayAsync();

        return allMoviesInWatchlists;
    }

    public async Task<bool> MovieExists(int movieId)
    {
        bool movieExits = await this._context
            .Watchlists
            .AnyAsync(w => w.Movie.Id == movieId);

        return movieExits;
    }

    public async Task RemoveAsync(int movieId)
    {
        // We assume that we will have a collection with a single element in case of correct add logic
        IEnumerable<Watchlist> watchlistsToRemove = await this._context
            .Watchlists
            .AsNoTracking()
            .Where(w => w.MovieId == movieId)
            .ToArrayAsync();

        this._context.RemoveRange(watchlistsToRemove);
        await this._context.SaveChangesAsync();
    }
}
