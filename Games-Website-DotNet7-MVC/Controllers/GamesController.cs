using Games_Website_DotNet7_MVC.Data;
using Games_Website_DotNet7_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Games_Website_DotNet7_MVC.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
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
                Categories = _context.Categories.Select(c => new SelectListItem { Value=c.Id.ToString(), Text =c.Name }).OrderBy(c => c.Text).ToList(),
                Devices = _context.Devices.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name }).OrderBy(c => c.Text).ToList()

            };

            return View(viewModel);
        }
    }
}
