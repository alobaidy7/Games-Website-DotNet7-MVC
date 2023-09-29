using Games_Website_DotNet7_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Games_Website_DotNet7_MVC.ViewModels
{
    public class CreateGameFormViewModel
    {

        public string Name { get; set; } = string.Empty;

        public IFormFile Cover { get; set; } = default!;
        
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Platforms Supported")]

        public List<int> SelectedDevices { get; set; } = new List<int>();

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;


    }
}