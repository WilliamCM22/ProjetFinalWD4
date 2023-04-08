namespace ProjetFinalWD4.Models
{
    public class Ouvrage
    {
        public int ID { get; set; }
        public required string Titre { get; set; }
        public required string Auteur { get; set; }
        public required int Exemplaires { get; set; }
        public List<Reservation> Reservations { get; set; } = new();
    }
}
