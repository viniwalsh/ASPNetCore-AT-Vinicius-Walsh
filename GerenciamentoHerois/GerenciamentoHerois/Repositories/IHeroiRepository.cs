using GerenciamentoHerois.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoHerois.Repositories
{
    public interface IHeroiRepository
    {
        IEnumerable<Heroi> Herois { get; }
        IEnumerable<Heroi> Codinomes { get; }

        Heroi GetHeroiByID(int HeroiID);
    }
}
