using System.Threading.Tasks;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class PoderController : Controller
    {
        private readonly IPoderService _poderService;

        public PoderController(IPoderService poderService)
        {
            _poderService = poderService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _poderService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _poderService.GetByIdAsync(id));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(PoderHeroiCreateViewModel poderHeroiCreateViewModel)
        {
            await _poderService.AddAsync(poderHeroiCreateViewModel.ToModel());

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _poderService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PoderModel poderModel)
        {
            await _poderService.EditAsync(poderModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _poderService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PoderModel poderModel)
        {
            await _poderService.RemoveAsync(poderModel);

            return RedirectToAction(nameof(Index));
        }
    }
}
