using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using A16_TP_1142718_JRompre.Data;
using A16_TP_1142718_JRompre.Models;
using System.Dynamic;
using System.Diagnostics;

namespace A16_TP_1142718_JRompre.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly A16_TP_1142718_JRompreContext _context;

        public ReservationsController(A16_TP_1142718_JRompreContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservation.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AutomobileId,DateReservation,DateSortie")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AutomobileId,DateReservation,DateSortie")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservation == null)
            {
                return Problem("Entity set 'A16_TP_1142718_JRompreContext.Reservation'  is null.");
            }
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Confirmer")]
        public async Task<IActionResult> ConfirmerReservation(int autoId, int clientId)
        {
            var client = await _context.Client.FindAsync(clientId);
            var auto = await _context.Automobile.FindAsync(autoId);

            if (client == null || auto == null)
            {
                return NotFound();
            }

            ViewModel vm = new ViewModel();
            vm.Automobile = auto;
            vm.Client = client;
            vm.DateReservation = DateTime.Now.ToString("yyyy-MM-dd");
            vm.DateSortie = DateTime.Now.ToString("yyyy-MM-dd");

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Enregistrer(int autoId, int clientId, string dateReservation, string dateSortie){
            Reservation res = new Reservation();
            res.AutomobileId = autoId;
            res.Client = _context.Client.Find(clientId);
            res.DateReservation = dateReservation;
            res.DateSortie = dateSortie;
            
            _context.Add(res);
            await _context.SaveChangesAsync();

            return RedirectToAction("Louer","Automobiles");
        }

        private bool ReservationExists(int id)
        {
          return _context.Reservation.Any(e => e.Id == id);
        }

    }
}
