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
    public class FavorietenLijstenController : Controller
    {
        private readonly FutureDBContext _context;

        public FavorietenLijstenController(FutureDBContext context)
        {
            _context = context;
        }

        // GET: FavorietenLijsten
        public async Task<IActionResult> Index()
        {
            return View(await _context.FavorietenLijsten.ToListAsync());
        }

        // GET: FavorietenLijsten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorietenLijsten = await _context.FavorietenLijsten
                .SingleOrDefaultAsync(m => m.Id == id);
            if (favorietenLijsten == null)
            {
                return NotFound();
            }

            return View(favorietenLijsten);
        }

        // GET: FavorietenLijsten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavorietenLijsten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GebruikersUsername")] FavorietenLijsten favorietenLijsten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorietenLijsten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favorietenLijsten);
        }

        // GET: FavorietenLijsten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorietenLijsten = await _context.FavorietenLijsten.SingleOrDefaultAsync(m => m.Id == id);
            if (favorietenLijsten == null)
            {
                return NotFound();
            }
            return View(favorietenLijsten);
        }

        // POST: FavorietenLijsten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GebruikersUsername")] FavorietenLijsten favorietenLijsten)
        {
            if (id != favorietenLijsten.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorietenLijsten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavorietenLijstenExists(favorietenLijsten.Id))
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
            return View(favorietenLijsten);
        }

        // GET: FavorietenLijsten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorietenLijsten = await _context.FavorietenLijsten
                .SingleOrDefaultAsync(m => m.Id == id);
            if (favorietenLijsten == null)
            {
                return NotFound();
            }

            return View(favorietenLijsten);
        }

        // POST: FavorietenLijsten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favorietenLijsten = await _context.FavorietenLijsten.SingleOrDefaultAsync(m => m.Id == id);
            _context.FavorietenLijsten.Remove(favorietenLijsten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavorietenLijstenExists(int id)
        {
            return _context.FavorietenLijsten.Any(e => e.Id == id);
        }
    }
}
