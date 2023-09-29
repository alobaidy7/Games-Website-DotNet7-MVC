namespace Games_Website_DotNet7_MVC.Models
{
    public class Category : BaseEntity
    {
       public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
