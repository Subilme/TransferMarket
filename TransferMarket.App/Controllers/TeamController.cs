using Microsoft.AspNetCore.Mvc;
using TransferMarket.App.Services;
using TransferMarket.App.Services.Impl;
using TransferMarket.Data;

namespace TransferMarket.App.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public IActionResult Index()
        {
            var teams = _teamRepository.GetAll();

            return View(teams);
        }

        public IActionResult Details(int id)
        {
            var team = _teamRepository.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        public IActionResult Create()
        {
            return View("Update", new Team());
        }

        public IActionResult Update(int? id)
        {
            if (id is null)
            {
                return View(new Team());
            }

            var team = _teamRepository.GetById((int)id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        [HttpPost]
        public IActionResult Update(Team model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id == 0)
            {
                var id = _teamRepository.Create(model);
                return RedirectToAction("Details", new { id });
            }

            if (!_teamRepository.Update(model))
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var team = _teamRepository.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            if (!_teamRepository.Delete(id))
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
