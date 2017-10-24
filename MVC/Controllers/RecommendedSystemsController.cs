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
    public class RecommendedSystemsController : Controller
    {
        private readonly FutureDBContext _context;

        public RecommendedSystemsController(FutureDBContext context)
        {
            _context = context;
        }

        // GET: RecommendedSystems
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecommendedSystems.ToListAsync());
        }

        // GET: RecommendedSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendedSystem = await _context.RecommendedSystems
                .SingleOrDefaultAsync(m => m.Id == id);
            if (recommendedSystem == null)
            {
                return NotFound();
            }

            return View(recommendedSystem);
        }

        // GET: RecommendedSystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecommendedSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gebruik,Level,Title,Short_Description,Long_Description,Image_Path,ProductsId")] RecommendedSystem recommendedSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recommendedSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recommendedSystem);
        }

        // GET: RecommendedSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendedSystem = await _context.RecommendedSystems.SingleOrDefaultAsync(m => m.Id == id);
            if (recommendedSystem == null)
            {
                return NotFound();
            }
            return View(recommendedSystem);
        }

        // POST: RecommendedSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gebruik,Level,Title,Short_Description,Long_Description,Image_Path,ProductsId")] RecommendedSystem recommendedSystem)
        {
            if (id != recommendedSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recommendedSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecommendedSystemExists(recommendedSystem.Id))
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
            return View(recommendedSystem);
        }

        // GET: RecommendedSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendedSystem = await _context.RecommendedSystems
                .SingleOrDefaultAsync(m => m.Id == id);
            if (recommendedSystem == null)
            {
                return NotFound();
            }

            return View(recommendedSystem);
        }

        // POST: RecommendedSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recommendedSystem = await _context.RecommendedSystems.SingleOrDefaultAsync(m => m.Id == id);
            _context.RecommendedSystems.Remove(recommendedSystem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecommendedSystemExists(int id)
        {
            return _context.RecommendedSystems.Any(e => e.Id == id);
        }
    }
}
