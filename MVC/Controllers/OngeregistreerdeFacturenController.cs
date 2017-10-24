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
    public class OngeregistreerdeFacturenController : Controller
    {
        private readonly FutureDBContext _context;

        public OngeregistreerdeFacturenController(FutureDBContext context)
        {
            _context = context;
        }

        // GET: OngeregistreerdeFacturen
        public async Task<IActionResult> Index()
        {
            var futureDBContext = _context.OngeregistreerdeFacturen.Include(o => o.OngeregistreerdeGebruiker);
            return View(await futureDBContext.ToListAsync());
        }

        // GET: OngeregistreerdeFacturen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ongeregistreerdeFactuur = await _context.OngeregistreerdeFacturen
                .Include(o => o.OngeregistreerdeGebruiker)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ongeregistreerdeFactuur == null)
            {
                return NotFound();
            }

            return View(ongeregistreerdeFactuur);
        }

        // GET: OngeregistreerdeFacturen/Create
        public IActionResult Create()
        {
            ViewData["OngeregistreerdeGebruikerId"] = new SelectList(_context.OngeregistreerdeGebruikers, "Id", "Id");
            return View();
        }

        // POST: OngeregistreerdeFacturen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FactuurBon,OngeregistreerdeGebruikerId")] OngeregistreerdeFactuur ongeregistreerdeFactuur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ongeregistreerdeFactuur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OngeregistreerdeGebruikerId"] = new SelectList(_context.OngeregistreerdeGebruikers, "Id", "Id", ongeregistreerdeFactuur.OngeregistreerdeGebruikerId);
            return View(ongeregistreerdeFactuur);
        }

        // GET: OngeregistreerdeFacturen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ongeregistreerdeFactuur = await _context.OngeregistreerdeFacturen.SingleOrDefaultAsync(m => m.Id == id);
            if (ongeregistreerdeFactuur == null)
            {
                return NotFound();
            }
            ViewData["OngeregistreerdeGebruikerId"] = new SelectList(_context.OngeregistreerdeGebruikers, "Id", "Id", ongeregistreerdeFactuur.OngeregistreerdeGebruikerId);
            return View(ongeregistreerdeFactuur);
        }

        // POST: OngeregistreerdeFacturen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FactuurBon,OngeregistreerdeGebruikerId")] OngeregistreerdeFactuur ongeregistreerdeFactuur)
        {
            if (id != ongeregistreerdeFactuur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ongeregistreerdeFactuur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OngeregistreerdeFactuurExists(ongeregistreerdeFactuur.Id))
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
            ViewData["OngeregistreerdeGebruikerId"] = new SelectList(_context.OngeregistreerdeGebruikers, "Id", "Id", ongeregistreerdeFactuur.OngeregistreerdeGebruikerId);
            return View(ongeregistreerdeFactuur);
        }

        // GET: OngeregistreerdeFacturen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ongeregistreerdeFactuur = await _context.OngeregistreerdeFacturen
                .Include(o => o.OngeregistreerdeGebruiker)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ongeregistreerdeFactuur == null)
            {
                return NotFound();
            }

            return View(ongeregistreerdeFactuur);
        }

        // POST: OngeregistreerdeFacturen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ongeregistreerdeFactuur = await _context.OngeregistreerdeFacturen.SingleOrDefaultAsync(m => m.Id == id);
            _context.OngeregistreerdeFacturen.Remove(ongeregistreerdeFactuur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OngeregistreerdeFactuurExists(int id)
        {
            return _context.OngeregistreerdeFacturen.Any(e => e.Id == id);
        }
    }
}
