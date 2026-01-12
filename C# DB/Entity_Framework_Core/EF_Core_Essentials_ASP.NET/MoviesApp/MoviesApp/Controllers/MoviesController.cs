using Microsoft.AspNetCore.Mvc;
using MoviesApp.Services.Interfaces;
using MoviesApp.ViewModels.Movies;

namespace MiniCinemaApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AllMoviesIndexViewModel> viewModels = await this._moviesService
                .GetAllMoviesListAsync();

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new AddMovieFormModel
            {
                ReleaseDate = DateTime.Today
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMovieFormModel model)
        {
            // Data direction is Import -> from UI to DB
            // => We need to validate the data
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this._moviesService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            MovieDetailsViewModel? viewModel = await this._moviesService
                .GetMovieDetailsByIdAsync(id);

            if (viewModel == null)
                return NotFound();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            AllMoviesIndexViewModel? viewModel = await this._moviesService
                .PrepareMovieViewModelForDeleteAsync(id);

            if (viewModel == null)
                return NotFound();

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool movieDeleted = await this._moviesService.DeleteAsync(id);

            if (!movieDeleted)
            {
                ModelState.AddModelError(string.Empty, "There was an unexpected error while deleting entity! Try again later!");

                return RedirectToAction(nameof(Delete), new { id });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
