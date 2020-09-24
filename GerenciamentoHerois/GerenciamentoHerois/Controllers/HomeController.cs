using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GerenciamentoHerois.Models;
using GerenciamentoHerois.Repositories;
using GerenciamentoHerois.ViewModels;

namespace GerenciamentoHerois.Controllers
{
    public class HomeController : Controller
    {
        public readonly IHeroiRepository _heroiRepository;

        public HomeController(IHeroiRepository heroiRepository)
        {
            _heroiRepository = heroiRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                HeroisPreferidos = _heroiRepository.Codinomes
            };

            return View(homeViewModel);
        }
    }
}
