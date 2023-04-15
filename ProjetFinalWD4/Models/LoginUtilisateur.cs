using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetFinalWD4.Models
{
    public class LoginUtilisateur
    {
  
        [EmailAddress]
        public required string Courriel { get; set; }
        [Column(TypeName = "varbinary(max)"), Display(Name = "Mot de passe"), DataType(DataType.Password)]
        public required string MotDePasse { get; set; }

    }
}
