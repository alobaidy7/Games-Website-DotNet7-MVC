using Games_Website_DotNet7_MVC.Data;
using Games_Website_DotNet7_MVC.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Games_Website_DotNet7_MVC.Services
{
    public class DevicesService : IDevicesService
    {
        private readonly ApplicationDbContext _context;

        public DevicesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {

            return _context.Categories
                 .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                 .OrderBy(c => c.Text)
                 .ToList();

        }
    }
}
