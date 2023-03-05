using Microsoft.AspNetCore.Mvc;
using TransferMarket.App.Services;

namespace TransferMarket.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public HomeController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IActionResult Index()
        {
            var games = _gameRepository.GetAll();

            return View(games);
        }
    }
}
