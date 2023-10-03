using Microsoft.AspNetCore.Mvc.Rendering;

namespace Games_Website_DotNet7_MVC.Interfaces
{
    public interface IDevicesService
    {
        IEnumerable<SelectListItem> GetSelectList();

    }
}
