using GerenciamentoHerois.Context;
using GerenciamentoHerois.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoHerois.Repositories
{
    public class HeroiRepository : IHeroiRepository
    {
        private readonly AppDbContext _context;
        public HeroiRepository(AppDbContext context)
        {
            _context = context; 
        }

        public IEnumerable<Heroi> Herois => _context.Herois.Include(c => c.Poder);

        public IEnumerable<Heroi> Codinomes => _context.Herois.Include(c => c.Poder);

        public Heroi GetHeroiByID(int HeroiID)
        {
            return _context.Herois.FirstOrDefault(c => c.HeroiID == HeroiID);
        }
    }
}
