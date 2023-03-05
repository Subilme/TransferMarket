using Microsoft.AspNetCore.Mvc;
using TransferMarket.App.Services;
using TransferMarket.App.ViewModels;
using TransferMarket.Data;

namespace TransferMarket.App.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGameRepository _gameRepository;
        private readonly ICardRepository _cardRepository;

        public PlayerController(IPlayerRepository playerRepository, IGameRepository gameRepository, ICardRepository cardRepository)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _cardRepository = cardRepository;
        }

        public IActionResult Index()
        {
            var players = _playerRepository.GetAll();

            return View(players);
        }

        public IActionResult Details(int id)
        {
            var player = _playerRepository.GetById(id);
            if (player == null)
            {
                return NotFound();
            }
            var games = _gameRepository.GetAll().ToList().FindAll(x => x.HomeTeamId == player.TeamId || x.GuestTeamId == player.TeamId);
            var cards = _cardRepository.GetAll().ToList().FindAll(x => x.PlayerId == player.Id);

            var viewModel = new PlayerViewModel
            {
                Name = player.Name,
                Team = player.Team.Name,
                Birthday = player.Birthday,
                Amplification = player.Amplification.Name,
                Price = player.Price,
                Games = games.Count,
                YellowCards = cards.Select(x => x.CardType.Name == "Желтая" || x.CardType.Name == "Вторая желтая").ToList().Count,
                RedCards = cards.Select(x => x.CardType.Name == "Красная").ToList().Count
            };
            foreach (var game in games)
            {
                viewModel.Goals += game.ScoredGoals.Select(x => x.PlayerScoredId == player.Id).ToList().Count;
            }

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View("Update", new Player());
        }

        public IActionResult Update(int? id)
        {
            if (id is null) 
            {
                return View(new Player());
            }

            var player = _playerRepository.GetById((int)id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        [HttpPost]
        public IActionResult Update(Player model)
        {
            if (model.Id == 0)
            {
                var id = _playerRepository.Create(model);
                return RedirectToAction("Details", new { id });
            }

            if (!_playerRepository.Update(model))
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var player = _playerRepository.GetById(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            if (!_playerRepository.Delete(id))
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
