using Games_Website_DotNet7_MVC.ViewModels;

namespace Games_Website_DotNet7_MVC.Interfaces
{
    public interface IGamesService
    {
        Task Create(CreateGameFormViewModel game);
    }
}
