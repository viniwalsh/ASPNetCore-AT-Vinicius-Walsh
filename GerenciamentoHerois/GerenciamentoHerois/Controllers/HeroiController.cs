using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoHerois.Models;
using GerenciamentoHerois.Repositories;
using GerenciamentoHerois.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoHerois.Controllers
{
    public class HeroiController : Controller
    {
        private readonly IHeroiRepository _heroiRepository;
        private readonly IPoderRepository _poderRepository;

        public HeroiController(IHeroiRepository heroiRepository, 
            IPoderRepository poderRepository)
        {
            _heroiRepository = heroiRepository;

            _poderRepository = poderRepository;
        }

        public IActionResult List(string poder)
        {
            string _poder = poder;
            IEnumerable<Heroi> herois;
            string poderAtual = string.Empty;

            if (string.IsNullOrEmpty(poder))
            {
                herois = _heroiRepository.Herois.OrderBy(l => l.HeroiID);
                poder = "Todos os Poderes";
            }

            var heroislistViewModel = new HeroiListViewModel();
            heroislistViewModel.Herois = _heroiRepository.Herois;
            heroislistViewModel.PoderAtual = "Poder Atual";
            return View(heroislistViewModel);
        }
    }
}
