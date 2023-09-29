using System.ComponentModel.DataAnnotations;

namespace Games_Website_DotNet7_MVC.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(50)]
        public string Icon { get; set; } = string.Empty;
    }
}
