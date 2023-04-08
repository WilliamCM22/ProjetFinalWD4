namespace ProjetFinalWD4.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public required Utilisateur Utilisateur { get; set; }
        public required Ouvrage Ouvrage { get; set; }
    }
}
