using Microsoft.AspNetCore.Mvc;
using MoviesApp.Services.Interfaces;
using MoviesApp.ViewModels.Import;

namespace MiniCinemaApp.Controllers
{
    public class ImportController : Controller
    {
        private readonly IImportService _importService;

        public ImportController(IImportService importService)
        {
            _importService = importService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ImportIndexViewModel();

            if (TempData.ContainsKey("JsonImportedCount"))
            {
                model.JsonImportedCount = (int)TempData["JsonImportedCount"]!;
            }

            if (TempData.ContainsKey("XmlImportedCount"))
            {
                model.XmlImportedCount = (int)TempData["XmlImportedCount"]!;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ImportJson()
        {
            const string jsonFileName = "moviesJSONFile.json";
            int importedCount = await this._importService.ImportFromJsonAsync(jsonFileName);

            TempData["JsonImportedCount"] = importedCount;

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ImportXml()
        {
            const string xmlFileName = "MoviesXMLFile.xml";
            int importedCount = await this._importService.ImportFromXmlAsync(xmlFileName);

            TempData["XmlImportedCount"] = importedCount;

            return RedirectToAction(nameof(Index));
        }
    }
}
