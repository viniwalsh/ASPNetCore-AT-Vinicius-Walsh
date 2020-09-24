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
            else
            {
                if (string.Equals(poderAtual, _poder, StringComparison.OrdinalIgnoreCase))
                {
                    herois = _heroiRepository.Herois.Where(l =>
                    l.Poder.TipoPoder.Equals(_poderRepository.Poderes)).OrderBy(l => l.Codinome);
                }

                poderAtual = _poder;
            }

            var heroislistViewModel = new HeroiListViewModel()
            {
                //Herois = herois,
                PoderAtual = poderAtual
            };
            return View(heroislistViewModel);
        }

        public IActionResult Details(int heroiId)
        {
            var heroi = _heroiRepository.Herois.FirstOrDefault(l => l.HeroiID == heroiId);
            if (heroi == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(heroi);
        }
        public IActionResult Search(string searchString)
        {
            string _searhString = searchString;
            IEnumerable<Heroi> herois;
            string _poderAtual = string.Empty;

            if (string.IsNullOrEmpty(_searhString))
            {
                herois = _heroiRepository.Herois.OrderBy(l => l.HeroiID);
            }
            else
            {
                herois = _heroiRepository.Herois.Where(l => l.Codinome.ToLower().Contains(_searhString.ToLower()));
            }

            return View("~/View/Lanche/List.cshtml", new HeroiListViewModel { Herois = herois, PoderAtual="Todos os Poderes"});
        }

    }
}
