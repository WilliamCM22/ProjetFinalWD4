using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using ProjetFinalWD4.Data;
using ProjetFinalWD4.Models;
using System.Collections.Immutable;

namespace ProjetFinalWD4.Controllers
{
    public class OuvrageController : Controller
    {
        private readonly Bibliotheque _bibliotheque;
        
        public OuvrageController(Bibliotheque bibliotheque)
        {
            _bibliotheque= bibliotheque;
        }
        //non necessaire....
        public async Task<IActionResult> Index()
        {
            var ouvrages = await _bibliotheque.Ouvrages.ToListAsync();
            return View(ouvrages);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString, string searchType)
        {
            // Get the list of books and reservations from your data source (e.g., database, in-memory data)
            var ouvrages = await _bibliotheque.Ouvrages.ToListAsync();
            var reservations = await _bibliotheque.Reservations.ToListAsync();

            // Filter the books based on the search criteria
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLowerInvariant();

                if (searchType == "Titre")
                {
                    ouvrages = ouvrages.Where(v => v.Titre.ToLowerInvariant().Contains(searchString)).ToList();
                }
                else if (searchType == "Auteur")
                {
                    ouvrages = ouvrages.Where(v => v.Auteur.ToLowerInvariant().Contains(searchString)).ToList();
                }
            }

            // Convert the filtered list of books to a list of BookViewModel objects
            var ouvragesReservations = ouvrages.Select(ouvrage => new OuvragesReservations
            {
                ID = ouvrage.ID,
                Titre = ouvrage.Titre,
                Auteur = ouvrage.Auteur,
                Exemplaires = ouvrage.Exemplaires,
                NombreDeReservations = ouvrage.Exemplaires - reservations.Count(reservation => reservation.Ouvrage.ID == ouvrage.ID)
            }).ToList();

            return View(ouvragesReservations);
        }

    }
}
