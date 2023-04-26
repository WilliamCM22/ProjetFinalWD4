using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinalWD4.Data;

namespace ProjetFinalWD4.Controllers
{
    public class ReservationController : Controller
    {
        private readonly Bibliotheque _bibliotheque;
        public ReservationController(Bibliotheque bibliotheque)
        {
            _bibliotheque = bibliotheque;
        }
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
