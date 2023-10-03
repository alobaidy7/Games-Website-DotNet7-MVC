using Games_Website_DotNet7_MVC.Data;
using Games_Website_DotNet7_MVC.Interfaces;
using Games_Website_DotNet7_MVC.Models;
using Games_Website_DotNet7_MVC.ViewModels;

namespace Games_Website_DotNet7_MVC.Services
{
    public class GamesService : IGamesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly string _imagesPath;

        public GamesService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _imagesPath = $"{_env.WebRootPath}/assets/images/games";
        }
        public async Task Create(CreateGameFormViewModel model)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path = Path.Combine(_imagesPath,coverName);

            using var stream = File.Create(path);
            await model.Cover.CopyToAsync(stream);
            stream.Dispose();

            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = coverName,
                Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList(),
            };

            _context.Games.Add(game);
            _context.SaveChanges();
        }
    }
}
