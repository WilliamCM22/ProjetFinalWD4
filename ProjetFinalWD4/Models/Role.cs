namespace ProjetFinalWD4.Models
{
    public class Role
    {
        public int ID { get; set; }
        public required string Nom { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; } = new();
    }
}
