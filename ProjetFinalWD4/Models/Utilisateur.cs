using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetFinalWD4.Models
{
    public enum Langue
    {
        Francais,
        Anglais
    }
    public class Utilisateur
    {
        public int ID { get; set; }
        public required string Prenom { get; set; }
        public required string Nom { get; set; }
        [EmailAddress]
        public required string Courriel { get; set; }
        [Column(TypeName = "varbinary(max)"), Display(Name = "Mot de passe"), DataType(DataType.Password)]
        public required string MotDePasse { get; set; }
        public required Langue Langue { get; set; }
        public required bool Administrateur { get; set; }
        public List<Reservation> Reservations { get; set; } = new();
        public List<Role> Roles { get; set; } = new();
    }
}
