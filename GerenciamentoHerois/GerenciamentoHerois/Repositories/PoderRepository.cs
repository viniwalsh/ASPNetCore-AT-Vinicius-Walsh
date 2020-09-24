using GerenciamentoHerois.Context;
using GerenciamentoHerois.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoHerois.Repositories
{
    public class PoderRepository : IPoderRepository
    {
        private readonly AppDbContext _context;
        public PoderRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Poder> Poderes => _context.Poderes;
    }
}
