using Games_Website_DotNet7_MVC.Data;
using Games_Website_DotNet7_MVC.Interfaces;
using Games_Website_DotNet7_MVC.Models;
using Games_Website_DotNet7_MVC.Services;
using Games_Website_DotNet7_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Games_Website_DotNet7_MVC.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;


        public GamesController(ApplicationDbContext context, 
            ICategoriesService categoriesService, 
            IDevicesService devicesService,
            IGamesService gamesService)
        {
            _context = context;
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() // this is for view the form not posting new game
        {

            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList()

        };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel viewModel) // this is for view the form not posting new game
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _categoriesService.GetSelectList();
                viewModel.Devices = _devicesService.GetSelectList();

                return View(viewModel);
            }

            await _gamesService.Create(viewModel);
            
            return RedirectToAction(nameof(Index));
        }

    }
}
