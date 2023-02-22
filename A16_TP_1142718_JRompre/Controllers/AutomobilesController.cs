using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using A16_TP_1142718_JRompre.Data;
using A16_TP_1142718_JRompre.Models;

namespace A16_TP_1142718_JRompre.Controllers
{
    public class AutomobilesController : Controller
    {
        private readonly A16_TP_1142718_JRompreContext _context;

        public AutomobilesController(A16_TP_1142718_JRompreContext context)
        {
            _context = context;
        }

        // GET: Automobiles
        public async Task<IActionResult> Index()
        {
              return View(await _context.Automobile.ToListAsync());
        }

        // GET: Automobiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Automobile == null)
            {
                return NotFound();
            }

            var automobile = await _context.Automobile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobile == null)
            {
                return NotFound();
            }

            return View(automobile);
        }

        // GET: Automobiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Automobiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Annee,Marque,Model,Motopropulsion,Transmission,Licence,Prix")] Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automobile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(automobile);
        }

        // GET: Automobiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Automobile == null)
            {
                return NotFound();
            }

            var automobile = await _context.Automobile.FindAsync(id);
            if (automobile == null)
            {
                return NotFound();
            }
            return View(automobile);
        }

        // POST: Automobiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Annee,Marque,Model,Motopropulsion,Transmission,Licence,Prix")] Automobile automobile)
        {
            if (id != automobile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automobile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobileExists(automobile.Id))
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
            return View(automobile);
        }

        // GET: Automobiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Automobile == null)
            {
                return NotFound();
            }

            var automobile = await _context.Automobile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobile == null)
            {
                return NotFound();
            }

            return View(automobile);
        }

        // POST: Automobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Automobile == null)
            {
                return Problem("Entity set 'A16_TP_1142718_JRompreContext.Automobile'  is null.");
            }
            var automobile = await _context.Automobile.FindAsync(id);
            if (automobile != null)
            {
                _context.Automobile.Remove(automobile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Louer()
        {
            return View(await _context.Automobile.ToListAsync());
        }

        private bool AutomobileExists(int id)
        {
          return _context.Automobile.Any(e => e.Id == id);
        }
    }
}
