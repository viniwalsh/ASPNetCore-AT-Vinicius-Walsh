using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoHerois.Context;
using GerenciamentoHerois.Models;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;

namespace GerenciamentoHerois.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHeroisController : Controller
    {
        private readonly AppDbContext _context;

        public AdminHeroisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminHerois
        /*        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Herois.Include(h => h.Poder);
            return View(await appDbContext.ToListAsync());
        }*/

        public async Task<AcceptedResult> Index(string filter, int pageindex = 1, string sort = "Codinome")
        {
            var resultado = _context.Herois.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Codinome.Contains(filter));
            }

            var model = await PagingList.CreateAsync(resultado, 5, pageindex, sort, "Codinome");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }


        // GET: Admin/AdminHerois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heroi = await _context.Herois
                .Include(h => h.Poder)
                .FirstOrDefaultAsync(m => m.HeroiID == id);
            if (heroi == null)
            {
                return NotFound();
            }

            return View(heroi);
        }

        // GET: Admin/AdminHerois/Create
        public IActionResult Create()
        {
            ViewData["PoderId"] = new SelectList(_context.Poderes, "PoderId", "Descricao");
            return View();
        }

        // POST: Admin/AdminHerois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeroiID,NomeCompleto,Codinome,Peso,Altura,ImagemUrl,PoderId")] Heroi heroi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heroi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoderId"] = new SelectList(_context.Poderes, "PoderId", "Descricao", heroi.PoderId);
            return View(heroi);
        }

        // GET: Admin/AdminHerois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heroi = await _context.Herois.FindAsync(id);
            if (heroi == null)
            {
                return NotFound();
            }
            ViewData["PoderId"] = new SelectList(_context.Poderes, "PoderId", "Descricao", heroi.PoderId);
            return View(heroi);
        }

        // POST: Admin/AdminHerois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HeroiID,NomeCompleto,Codinome,Peso,Altura,ImagemUrl,PoderId")] Heroi heroi)
        {
            if (id != heroi.HeroiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heroi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeroiExists(heroi.HeroiID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoderId"] = new SelectList(_context.Poderes, "PoderId", "Descricao", heroi.PoderId);
            return View(heroi);
        }

        // GET: Admin/AdminHerois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heroi = await _context.Herois
                .Include(h => h.Poder)
                .FirstOrDefaultAsync(m => m.HeroiID == id);
            if (heroi == null)
            {
                return NotFound();
            }

            return View(heroi);
        }

        // POST: Admin/AdminHerois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var heroi = await _context.Herois.FindAsync(id);
            _context.Herois.Remove(heroi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeroiExists(int id)
        {
            return _context.Herois.Any(e => e.HeroiID == id);
        }
    }
}
