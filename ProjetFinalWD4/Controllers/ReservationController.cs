using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinalWD4.Data;
using ProjetFinalWD4.Models;
using System.Data;
using System.Security.Claims;

namespace ProjetFinalWD4.Controllers
{
    public class ReservationController : Controller
    {
        private readonly Bibliotheque _bibliotheque;
        public ReservationController(Bibliotheque bibliotheque)
        {
            _bibliotheque = bibliotheque;
        }
        [Authorize(Roles = "Admin, Usager")]
        public async Task<IActionResult> Index(int id)
        {
            var reservations = await _bibliotheque.Reservations
                .Include(v => v.Ouvrage)
                .Where(v => v.Utilisateur.ID == id) 
                .ToListAsync();
            
            return View(reservations);
        }
        [Authorize(Roles = "Admin, Usager")]
        public async Task<IActionResult> Ajout(int id)
        {
            var ouvrage = await _bibliotheque.Ouvrages.FindAsync(id);

            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var user = await _bibliotheque.Utilisateurs.FindAsync(userId);
           

            var reservation = new Reservation
            {
                Ouvrage = ouvrage,
                Utilisateur = user
            };

            _bibliotheque.Reservations.Add(reservation);
            await _bibliotheque.SaveChangesAsync();

            return RedirectToAction("Index", "Ouvrage");

        }
        [Authorize(Roles = "Admin, Usager")]
        public async Task<IActionResult> Confirmation(int id)
        {
            var reservation = await _bibliotheque.Reservations.FindAsync(id);

            if (reservation != null)
            {
                return View(reservation);
            }

            return NotFound();
        }
        [Authorize(Roles = "Admin, Usager")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Suppression(int id)
        {
            var reservation = await _bibliotheque.Reservations.FindAsync(id);
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            if (reservation != null)
            {
                _bibliotheque.Reservations.Remove(reservation);
                await _bibliotheque.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { id = userId });
            }

            return NotFound();
        }

    }
}
