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
    public class FactuurLijstenController : Controller
    {
        private readonly FutureDBContext _context;

        public FactuurLijstenController(FutureDBContext context)
        {
            _context = context;
        }

        // GET: FactuurLijsten
        public async Task<IActionResult> Index()
        {
            return View(await _context.FactuurLijsten.ToListAsync());
        }

        // GET: FactuurLijsten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuurLijsten = await _context.FactuurLijsten
                .SingleOrDefaultAsync(m => m.Id == id);
            if (factuurLijsten == null)
            {
                return NotFound();
            }

            return View(factuurLijsten);
        }

        // GET: FactuurLijsten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FactuurLijsten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GebruikerUsername")] FactuurLijsten factuurLijsten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factuurLijsten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factuurLijsten);
        }

        // GET: FactuurLijsten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuurLijsten = await _context.FactuurLijsten.SingleOrDefaultAsync(m => m.Id == id);
            if (factuurLijsten == null)
            {
                return NotFound();
            }
            return View(factuurLijsten);
        }

        // POST: FactuurLijsten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GebruikerUsername")] FactuurLijsten factuurLijsten)
        {
            if (id != factuurLijsten.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factuurLijsten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactuurLijstenExists(factuurLijsten.Id))
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
            return View(factuurLijsten);
        }

        // GET: FactuurLijsten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuurLijsten = await _context.FactuurLijsten
                .SingleOrDefaultAsync(m => m.Id == id);
            if (factuurLijsten == null)
            {
                return NotFound();
            }

            return View(factuurLijsten);
        }

        // POST: FactuurLijsten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factuurLijsten = await _context.FactuurLijsten.SingleOrDefaultAsync(m => m.Id == id);
            _context.FactuurLijsten.Remove(factuurLijsten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactuurLijstenExists(int id)
        {
            return _context.FactuurLijsten.Any(e => e.Id == id);
        }
    }
}
