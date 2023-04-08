using Microsoft.EntityFrameworkCore;
using ProjetFinalWD4.Models;

namespace ProjetFinalWD4.Data
{
    public class Bibliotheque : DbContext
    {
        public static readonly ILoggerFactory loggerFactory
            = LoggerFactory.Create(builder => builder.AddSimpleConsole());

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Ouvrage> Ouvrages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(Bibliotheque.loggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer("Server=.;Database=ProjetFinalWD4;Encrypt=False;Trusted_Connection=True;");
        }

    }
}
