using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ProjetFinalWD4.Data;
using ProjetFinalWD4.Models.ViewModels;

namespace ProjetFinalWD4.Components
{
    public class LoginViewComponent : ViewComponent
    {

        private readonly IHttpContextAccessor _context;
        private readonly Bibliotheque _bibliotheque;

        public LoginViewComponent(IHttpContextAccessor context, Bibliotheque bibliotheque)
        {
            _context = context;
            _bibliotheque = bibliotheque;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var isAuthenticated = _context.HttpContext?.User.Identity?.IsAuthenticated;

            if (isAuthenticated != null && (bool)isAuthenticated)
            {
                var id = Int32.Parse(_context.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                var utilisateur = await _bibliotheque.Utilisateurs.FindAsync(id);
                int nombreDeReservations = _bibliotheque.Reservations.Count(r => r.Utilisateur.ID == id);
                return View(new LoginViewModel(true, utilisateur!.Prenom, utilisateur!.Nom, nombreDeReservations));
            }

            return View(new LoginViewModel(false, null, null, 0));
        }

    }
}
