using GerenciamentoHerois.Models;
using System.Collections.Generic;

namespace GerenciamentoHerois.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Heroi> HeroisPreferidos { get; set; }
    }
}
