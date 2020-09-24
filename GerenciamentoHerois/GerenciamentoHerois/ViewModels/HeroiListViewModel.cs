using GerenciamentoHerois.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoHerois.ViewModels
{
    public class HeroiListViewModel
    {
        public IEnumerable<Heroi> Herois { get; set; }

        public string PoderAtual { get; set; }
    }
}
