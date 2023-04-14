namespace ProjetFinalWD4.Models.ViewModels
{
    public class LoginViewModel
    {
        public readonly bool IsAuthenticated;
        public readonly string? Prenom;
        public readonly string? Nom;
        public readonly int? NombreDeReservations;

        public LoginViewModel(bool isAuthenticated, string? prenom, string? nom, int? nombreDeReservations)
        {
            IsAuthenticated = isAuthenticated;
            Prenom = prenom;
            Nom = nom;
            NombreDeReservations = nombreDeReservations;
        }
    }
}
