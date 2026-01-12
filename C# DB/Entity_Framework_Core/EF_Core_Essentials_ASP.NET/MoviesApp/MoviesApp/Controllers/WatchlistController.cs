using Microsoft.AspNetCore.Mvc;
using MoviesApp.Services.Interfaces;
using MoviesApp.ViewModels.Movies;

namespace MoviesApp.Controllers
{
    public class WatchlistController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly IWatchlistService _watchlistService;

        public WatchlistController(IWatchlistService watchlistService ,IMoviesService moviesService)
        {
            this._moviesService = moviesService;
            this._watchlistService = watchlistService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllMoviesIndexViewModel> viewModels = await this._moviesService
                .GetAllMoviesListAsync();

            return View(viewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            bool movieExists = await this._moviesService.ExistsAsync(id);

            if (!movieExists)
                return NotFound();

            bool movieAddedToWatchlist = await this._watchlistService
                .AddMovieToWatchlistAsync(id);

            if (movieAddedToWatchlist)
                return RedirectToAction("Index", "Watchlist");

            return RedirectToAction("Index", "Watchlist");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await this._watchlistService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
