using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace Models
{
    public class FactuurController : Controller
    {
        private readonly FutureDBContext _context;

        public FactuurController(FutureDBContext context)
        {
            _context = context;
        }

        // GET: Factuur
        public async Task<IActionResult> Index()
        {
            var futureDBContext = _context.Facturen.Include(f => f.Gebruiker);
            return View(await futureDBContext.ToListAsync());
        }

        // GET: Factuur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuur = await _context.Facturen
                .Include(f => f.Gebruiker)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (factuur == null)
            {
                return NotFound();
            }

            return View(factuur);
        }

        // GET: Factuur/Create
        public IActionResult Create()
        {
            ViewData["GebruikerId"] = new SelectList(_context.gebruikers, "Id", "Id");
            return View();
        }

        // POST: Factuur/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FactuurBon,GebruikerId")] Factuur factuur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factuur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GebruikerId"] = new SelectList(_context.gebruikers, "Id", "Id", factuur.GebruikerId);
            return View(factuur);
        }

        // GET: Factuur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuur = await _context.Facturen.SingleOrDefaultAsync(m => m.Id == id);
            if (factuur == null)
            {
                return NotFound();
            }
            ViewData["GebruikerId"] = new SelectList(_context.gebruikers, "Id", "Id", factuur.GebruikerId);
            return View(factuur);
        }

        // POST: Factuur/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FactuurBon,GebruikerId")] Factuur factuur)
        {
            if (id != factuur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factuur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactuurExists(factuur.Id))
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
            ViewData["GebruikerId"] = new SelectList(_context.gebruikers, "Id", "Id", factuur.GebruikerId);
            return View(factuur);
        }

        // GET: Factuur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuur = await _context.Facturen
                .Include(f => f.Gebruiker)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (factuur == null)
            {
                return NotFound();
            }

            return View(factuur);
        }

        // POST: Factuur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factuur = await _context.Facturen.SingleOrDefaultAsync(m => m.Id == id);
            _context.Facturen.Remove(factuur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactuurExists(int id)
        {
            return _context.Facturen.Any(e => e.Id == id);
        }
    }
}
