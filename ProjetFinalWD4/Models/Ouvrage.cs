using ProjetFinalWD4.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetFinalWD4.Models
{
    public class Ouvrage
    {



        public int ID { get; set; }
        public required string Titre { get; set; }
        public required string Auteur { get; set; }
        public required int Exemplaires { get; set; }
        public List<Reservation> Reservations { get; set; } = new();
        [Display(Name = "Copies Disponible")]




        ////ceci doit aller dans le controlleur



        public int QuantiteDisponible
        {
            get
            {
                using (var context = new Bibliotheque())
                {
                    var nombreDeReservations = context.Reservations
                        .Where(r => r.Ouvrage.ID == this.ID)
                        .Count();

                    return this.Exemplaires - nombreDeReservations;
                }
            }
        }


    }
}
