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
    public class HistoriqueReservationsController : Controller
    {
        private readonly A16_TP_1142718_JRompreContext _context;

        public HistoriqueReservationsController(A16_TP_1142718_JRompreContext context)
        {
            _context = context;
        }

        // GET: HistoriqueReservations
        public async Task<IActionResult> Index()
        {
              return View(await _context.HistoriqueReservation.ToListAsync());
        }

        // GET: HistoriqueReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HistoriqueReservation == null)
            {
                return NotFound();
            }

            var historiqueReservation = await _context.HistoriqueReservation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historiqueReservation == null)
            {
                return NotFound();
            }

            return View(historiqueReservation);
        }

        // GET: HistoriqueReservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistoriqueReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AutomobileId,DateReservation,DateSortie,DateRetour")] HistoriqueReservation historiqueReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historiqueReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historiqueReservation);
        }

        // GET: HistoriqueReservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HistoriqueReservation == null)
            {
                return NotFound();
            }

            var historiqueReservation = await _context.HistoriqueReservation.FindAsync(id);
            if (historiqueReservation == null)
            {
                return NotFound();
            }
            return View(historiqueReservation);
        }

        // POST: HistoriqueReservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AutomobileId,DateReservation,DateSortie,DateRetour")] HistoriqueReservation historiqueReservation)
        {
            if (id != historiqueReservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historiqueReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriqueReservationExists(historiqueReservation.Id))
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
            return View(historiqueReservation);
        }

        // GET: HistoriqueReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HistoriqueReservation == null)
            {
                return NotFound();
            }

            var historiqueReservation = await _context.HistoriqueReservation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historiqueReservation == null)
            {
                return NotFound();
            }

            return View(historiqueReservation);
        }

        // POST: HistoriqueReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HistoriqueReservation == null)
            {
                return Problem("Entity set 'A16_TP_1142718_JRompreContext.HistoriqueReservation'  is null.");
            }
            var historiqueReservation = await _context.HistoriqueReservation.FindAsync(id);
            if (historiqueReservation != null)
            {
                _context.HistoriqueReservation.Remove(historiqueReservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriqueReservationExists(int id)
        {
          return _context.HistoriqueReservation.Any(e => e.Id == id);
        }
    }
}
