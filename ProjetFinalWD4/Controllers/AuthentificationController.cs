using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinalWD4.Controllers;
using ProjetFinalWD4.Models;
using System.Security.Claims;
using ProjetFinalWD4.Data;


namespace ProjetFinalWD4.Controllers
{
    public class AuthentificationController : Controller
    {
        private readonly Bibliotheque _bibliotheque;

        public AuthentificationController(Bibliotheque bibliotheque)
        {
            _bibliotheque = bibliotheque;
        }
        public IActionResult Connexion()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Connexion(LoginUtilisateur formulaire, string? ReturnUrl)
        {
            if (!ModelState.IsValid) { return View(); }

            var user = await _bibliotheque.Utilisateurs.FromSql($@"
                SELECT * FROM [Utilisateurs]
                WHERE [Courriel] = {formulaire.Courriel}
                AND [MotDePasse] = HASHBYTES('SHA2_256', {formulaire.MotDePasse})
            ")
                .Include(v => v.Roles)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "informations invalides");
                return View();
            }

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Email, user.Courriel),
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
            };

            user.Roles.ForEach(role => {
                claims.Add(new Claim(ClaimTypes.Role, role.Nom));
            });

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                new AuthenticationProperties { });

            return ReturnUrl != null ? LocalRedirect(ReturnUrl) : RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Authorize(Roles = "Admin, Usager")]
        public async Task<IActionResult> Deconnexion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Interdit()
        {
            return View();
        }
    }
}
