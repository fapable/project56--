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
    public class FavorietenController : Controller
    {
        private readonly FutureDBContext _context;

        public FavorietenController(FutureDBContext context)
        {
            _context = context;
        }

        // GET: Favorieten
        public async Task<IActionResult> Index()
        {
            var futureDBContext = _context.Favorieten.Include(f => f.FavorietenLijsten);
            return View(await futureDBContext.ToListAsync());
        }

        // GET: Favorieten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorieten = await _context.Favorieten
                .Include(f => f.FavorietenLijsten)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (favorieten == null)
            {
                return NotFound();
            }

            return View(favorieten);
        }

        // GET: Favorieten/Create
        public IActionResult Create()
        {
            ViewData["FavorietenLijstenId"] = new SelectList(_context.FavorietenLijsten, "Id", "Id");
            return View();
        }

        // POST: Favorieten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FavorietenLijstenId,ProductsId")] Favorieten favorieten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorieten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FavorietenLijstenId"] = new SelectList(_context.FavorietenLijsten, "Id", "Id", favorieten.FavorietenLijstenId);
            return View(favorieten);
        }

        // GET: Favorieten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorieten = await _context.Favorieten.SingleOrDefaultAsync(m => m.Id == id);
            if (favorieten == null)
            {
                return NotFound();
            }
            ViewData["FavorietenLijstenId"] = new SelectList(_context.FavorietenLijsten, "Id", "Id", favorieten.FavorietenLijstenId);
            return View(favorieten);
        }

        // POST: Favorieten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FavorietenLijstenId,ProductsId")] Favorieten favorieten)
        {
            if (id != favorieten.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorieten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavorietenExists(favorieten.Id))
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
            ViewData["FavorietenLijstenId"] = new SelectList(_context.FavorietenLijsten, "Id", "Id", favorieten.FavorietenLijstenId);
            return View(favorieten);
        }

        // GET: Favorieten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorieten = await _context.Favorieten
                .Include(f => f.FavorietenLijsten)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (favorieten == null)
            {
                return NotFound();
            }

            return View(favorieten);
        }

        // POST: Favorieten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favorieten = await _context.Favorieten.SingleOrDefaultAsync(m => m.Id == id);
            _context.Favorieten.Remove(favorieten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavorietenExists(int id)
        {
            return _context.Favorieten.Any(e => e.Id == id);
        }
    }
}
