using System.Threading.Tasks;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class HeroiController : Controller
    {
        private readonly IHeroiService _heroiService;

        public HeroiController(IHeroiService heroiService)
        {
            _heroiService = heroiService;
        }

        public async Task<IActionResult> Index(string search)
        {
            ViewBag.Search = search;
            return View(await _heroiService.GetAllAsync(search));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _heroiService.GetByIdAsync(id));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(HeroiModel heroiModel)
        {
            var heroiId = await _heroiService.AddAsync(heroiModel);

            return RedirectToAction(nameof(Details), new { id = heroiId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _heroiService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HeroiModel heroiModel)
        {
            await _heroiService.EditAsync(heroiModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _heroiService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HeroiModel heroiModel)
        {
            await _heroiService.RemoveAsync(heroiModel);

            return RedirectToAction(nameof(Index));
        }
    }
}
