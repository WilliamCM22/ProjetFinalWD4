namespace ProjetFinalWD4.Models
{
    public class OuvragesReservations
    {
        public int ID { get; set; }
        public required string Titre { get; set; }
        public required string Auteur { get; set; }
        public required int Exemplaires { get; set; }
        public required int NombreDeReservations { get; set; }
    }
}
