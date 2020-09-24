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
    public class AdminPoderesController : Controller
    {
        private readonly AppDbContext _context;

        public AdminPoderesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminPoders
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Poderes.ToListAsync());
        //}

        public async Task<AcceptedResult> Index(string filter, int pageindex = 1, string sort = "TipoPoder")
        {
            var resultado = _context.Poderes.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.TipoPoder.Contains(filter));
            }

            var model = await PagingList.CreateAsync(resultado, 5, pageindex, sort, "TipoPoder");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        // GET: Admin/AdminPoders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poder = await _context.Poderes
                .FirstOrDefaultAsync(m => m.PoderId == id);
            if (poder == null)
            {
                return NotFound();
            }

            return View(poder);
        }

        // GET: Admin/AdminPoders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPoders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoderId,TipoPoder,Descricao")] Poder poder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poder);
        }

        // GET: Admin/AdminPoders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poder = await _context.Poderes.FindAsync(id);
            if (poder == null)
            {
                return NotFound();
            }
            return View(poder);
        }

        // POST: Admin/AdminPoders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PoderId,TipoPoder,Descricao")] Poder poder)
        {
            if (id != poder.PoderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoderExists(poder.PoderId))
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
            return View(poder);
        }

        // GET: Admin/AdminPoders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poder = await _context.Poderes
                .FirstOrDefaultAsync(m => m.PoderId == id);
            if (poder == null)
            {
                return NotFound();
            }

            return View(poder);
        }

        // POST: Admin/AdminPoders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poder = await _context.Poderes.FindAsync(id);
            _context.Poderes.Remove(poder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoderExists(int id)
        {
            return _context.Poderes.Any(e => e.PoderId == id);
        }
    }
}
