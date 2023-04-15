using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using ProjetFinalWD4.Data;
using ProjetFinalWD4.Models;

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
            var ouvrages = await _bibliotheque.Ouvrages.ToListAsync();

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

            return View(ouvrages);
        }


    }
}
