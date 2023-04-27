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
    }
}
