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
    public class OngeregistreerdeGebruikerController : Controller
    {
        private readonly FutureDBContext _context;

        public OngeregistreerdeGebruikerController(FutureDBContext context)
        {
            _context = context;
        }

        // GET: OngeregistreerdeGebruiker
        public async Task<IActionResult> Index()
        {
            return View(await _context.OngeregistreerdeGebruikers.ToListAsync());
        }

        // GET: OngeregistreerdeGebruiker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ongeregistreerdeGebruiker = await _context.OngeregistreerdeGebruikers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ongeregistreerdeGebruiker == null)
            {
                return NotFound();
            }

            return View(ongeregistreerdeGebruiker);
        }

        // GET: OngeregistreerdeGebruiker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OngeregistreerdeGebruiker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EMail,Voornaam,Achternaam,Straat,Huisnummer,Postcode,Stad,Telefoonnummer")] OngeregistreerdeGebruiker ongeregistreerdeGebruiker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ongeregistreerdeGebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ongeregistreerdeGebruiker);
        }

        // GET: OngeregistreerdeGebruiker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ongeregistreerdeGebruiker = await _context.OngeregistreerdeGebruikers.SingleOrDefaultAsync(m => m.Id == id);
            if (ongeregistreerdeGebruiker == null)
            {
                return NotFound();
            }
            return View(ongeregistreerdeGebruiker);
        }

        // POST: OngeregistreerdeGebruiker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EMail,Voornaam,Achternaam,Straat,Huisnummer,Postcode,Stad,Telefoonnummer")] OngeregistreerdeGebruiker ongeregistreerdeGebruiker)
        {
            if (id != ongeregistreerdeGebruiker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ongeregistreerdeGebruiker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OngeregistreerdeGebruikerExists(ongeregistreerdeGebruiker.Id))
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
            return View(ongeregistreerdeGebruiker);
        }

        // GET: OngeregistreerdeGebruiker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ongeregistreerdeGebruiker = await _context.OngeregistreerdeGebruikers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ongeregistreerdeGebruiker == null)
            {
                return NotFound();
            }

            return View(ongeregistreerdeGebruiker);
        }

        // POST: OngeregistreerdeGebruiker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ongeregistreerdeGebruiker = await _context.OngeregistreerdeGebruikers.SingleOrDefaultAsync(m => m.Id == id);
            _context.OngeregistreerdeGebruikers.Remove(ongeregistreerdeGebruiker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OngeregistreerdeGebruikerExists(int id)
        {
            return _context.OngeregistreerdeGebruikers.Any(e => e.Id == id);
        }
    }
}
