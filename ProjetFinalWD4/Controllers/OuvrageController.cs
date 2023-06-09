﻿using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin, Usager")]
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, string searchType)
        {
            var ouvrages = await _bibliotheque.Ouvrages.ToListAsync();
            var reservations = await _bibliotheque.Reservations.ToListAsync();
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var reservationCount = await _bibliotheque.Reservations
                .CountAsync(v => v.Utilisateur.ID == userId);

            ViewBag.ReservationCount = reservationCount;

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

            var ouvragesReservations = ouvrages.Select(ouvrage => new OuvragesReservations
            {
                ID = ouvrage.ID,
                Titre = ouvrage.Titre,
                Auteur = ouvrage.Auteur,
                Exemplaires = ouvrage.Exemplaires,
                QuantiteDisponible = ouvrage.Exemplaires - reservations.Count(reservation => reservation.Ouvrage.ID == ouvrage.ID)
            }).ToList();

            return View(ouvragesReservations);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Modification(int id)
        {
            var ouvrage = await _bibliotheque.Ouvrages.FindAsync(id);
            var reservations = await _bibliotheque.Reservations.ToListAsync();

            if (ouvrage != null)
            {
                var ouvragesReservations = new OuvragesReservations
                {
                    ID = ouvrage.ID,
                    Titre = ouvrage.Titre,
                    Auteur = ouvrage.Auteur,
                    Exemplaires = ouvrage.Exemplaires,
                    QuantiteDisponible = ouvrage.Exemplaires - reservations.Count(reservation => reservation.Ouvrage.ID == ouvrage.ID)
                };

                return View(ouvragesReservations);
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modification(int id, OuvragesReservations données)
        {
            if (!ModelState.IsValid)
            {
                return View(données);
            }

            var ouvrage = await _bibliotheque.Ouvrages.FindAsync(id);

            if (ouvrage != null)
            {
                ouvrage.Titre = données.Titre;
                ouvrage.Auteur = données.Auteur;
                ouvrage.Exemplaires = données.Exemplaires;

                var reservations = await _bibliotheque.Reservations.Where(r => r.Ouvrage.ID == id).ToListAsync();
                foreach (var reservation in reservations)
                {
                    _bibliotheque.Reservations.Remove(reservation);
                }

                await _bibliotheque.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }


    }
}
