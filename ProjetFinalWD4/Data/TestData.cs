using Microsoft.EntityFrameworkCore;
using ProjetFinalWD4.Models;

namespace ProjetFinalWD4.Data
{
    public static class TestData
    {
        public async static Task Charger(Bibliotheque bibliotheque)
        {
            await bibliotheque.Database.MigrateAsync();

            if (await bibliotheque.Utilisateurs.AnyAsync())
            {
                return;
            }

            var roleAdmin = new Role { Nom = "Admin" };
            var roleUsager = new Role { Nom = "Usager" };

            await bibliotheque.Roles.AddRangeAsync(new Role[] {roleAdmin, roleUsager});

            var henri = (await bibliotheque.Utilisateurs.FromSql($@"
                INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
                OUTPUT INSERTED.ID, INSERTED.Prenom,  INSERTED.Nom, INSERTED.Courriel, INSERTED.MotDePasse, INSERTED.Langue, INSERTED.Administrateur
                VALUES ({"Henri"}, {"Delpech"}, {"henri.delpech@gmail.com"}, HASHBYTES('SHA2_256', {"test1"}), {0}, {"false"})
            ").ToListAsync())[0];

            var anais = (await bibliotheque.Utilisateurs.FromSql($@"
                INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
                OUTPUT INSERTED.ID, INSERTED.Prenom,  INSERTED.Nom, INSERTED.Courriel, INSERTED.MotDePasse, INSERTED.Langue, INSERTED.Administrateur
                VALUES ({"Anais"}, {"Laventure"}, {"anais.laventure@gmail.com"}, HASHBYTES('SHA2_256', {"test2"}), {0}, {"true"})
            ").ToListAsync())[0];

            var felix = (await bibliotheque.Utilisateurs.FromSql($@"
                INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
                OUTPUT INSERTED.ID, INSERTED.Prenom,  INSERTED.Nom, INSERTED.Courriel, INSERTED.MotDePasse, INSERTED.Langue, INSERTED.Administrateur
                VALUES ({"Felix"}, {"Dionne"}, {"felix.dionne@gmail.com"}, HASHBYTES('SHA2_256', {"test3"}), {0}, {"false"})
            ").ToListAsync())[0];

            var michel = (await bibliotheque.Utilisateurs.FromSql($@"
                INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
                OUTPUT INSERTED.ID, INSERTED.Prenom,  INSERTED.Nom, INSERTED.Courriel, INSERTED.MotDePasse, INSERTED.Langue, INSERTED.Administrateur
                VALUES ({"Michel"}, {"Toussaint"}, {"michel.toussaint@gmail.com"}, HASHBYTES('SHA2_256', {"test4"}), {0}, {"false"})
            ").ToListAsync())[0];

            var kinza = (await bibliotheque.Utilisateurs.FromSql($@"
                INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
                OUTPUT INSERTED.ID, INSERTED.Prenom,  INSERTED.Nom, INSERTED.Courriel, INSERTED.MotDePasse, INSERTED.Langue, INSERTED.Administrateur
                VALUES ({"Kinza"}, {"Bacha"}, {"kinza.bacha@gmail.com"}, HASHBYTES('SHA2_256', {"test5"}), {0}, {"false"})
            ").ToListAsync())[0];

            var Jian = (await bibliotheque.Utilisateurs.FromSql($@"
                INSERT INTO [Utilisateurs] ([Prenom], [Nom], [Courriel], [MotDePasse], [Langue], [Administrateur])
                OUTPUT INSERTED.ID, INSERTED.Prenom,  INSERTED.Nom, INSERTED.Courriel, INSERTED.MotDePasse, INSERTED.Langue, INSERTED.Administrateur
                VALUES ({"Jian"}, {"Xiaochun"}, {"jian.xiaochun@gmail.com"}, HASHBYTES('SHA2_256', {"test6"}), {1}, {"false"})
            ").ToListAsync())[0];


            henri.Roles.Add(roleUsager);
            anais.Roles.Add(roleAdmin);
            felix.Roles.Add(roleUsager);
            michel.Roles.Add(roleUsager);
            kinza.Roles.Add(roleUsager);
            Jian.Roles.Add(roleUsager);

            var ouvrage1 = new Ouvrage()
            {
                Titre = "Stupeur et Tremblements",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1
            };

            var ouvrage2 = new Ouvrage()
            {
                Titre = "Une forme de vie",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1
            };

            var ouvrage3 = new Ouvrage()
            {
                Titre = "Barbe bleu",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1
            };

            var ouvrage4 = new Ouvrage()
            {
                Titre = "Journal d'Hirondelle",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1
            };

            var ouvrage5 = new Ouvrage()
            {
                Titre = "Acide Sulfurique",
                Auteur = "Amelie Nothomb",
                Exemplaires = 2
            };

            var ouvrage6 = new Ouvrage()
            {
                Titre = "Le Mystere par excellence",
                Auteur = "Amelie Nothomb",
                Exemplaires = 2
            };

            var ouvrage7 = new Ouvrage()
            {
                Titre = "Le Sabotage amoureux",
                Auteur = "Amelie Nothomb",
                Exemplaires = 2
            };

            var ouvrage8 = new Ouvrage()
            {
                Titre = "Le voyage d'hiver",
                Auteur = "Amelie Nothomb",
                Exemplaires = 2
            };

            var ouvrage9 = new Ouvrage()
            {
                Titre = "Les Catillinaires",
                Auteur = "Amelie Nothomb",
                Exemplaires = 1
            };

            var ouvrage10 = new Ouvrage()
            {
                Titre = "Metaphysique Des Tubes",
                Auteur = "Amelie Nothomb",
                Exemplaires = 3
            };

            var ouvrage11 = new Ouvrage()
            {
                Titre = "Premier bilan apres l'apocalypse",
                Auteur = "Frederic Beigbeder",
                Exemplaires = 1
            };

            var ouvrage12 = new Ouvrage()
            {
                Titre = "Au secours pardon",
                Auteur = "Frederic Beigbeder",
                Exemplaires = 1
            };

            var ouvrage13 = new Ouvrage()
            {
                Titre = "Un roman francais",
                Auteur = "Frederic Beigbeder",
                Exemplaires = 1
            };

            var ouvrage14 = new Ouvrage()
            {
                Titre = "Memoires D'Un jeune Homme Derange",
                Auteur = "Frederic Beigbeder",
                Exemplaires = 1
            };

            var ouvrage15 = new Ouvrage()
            {
                Titre = "99 Francs",
                Auteur = "Frederic Beigbeder",
                Exemplaires = 1
            };

            var ouvrage16 = new Ouvrage()
            {
                Titre = "L'homme qui pleure de rire",
                Auteur = "Frederic Beigbeder",
                Exemplaires = 2
            };

            var ouvrage17 = new Ouvrage()
            {
                Titre = "Vacances dans le coma",
                Auteur = "Frederic Beigbeder",
                Exemplaires = 1
            };

            var ouvrage18 = new Ouvrage()
            {
                Titre = "La frivolite est une affaire serieuse",
                Auteur = "Frederic Beigbeder",
                Exemplaires = 1
            };

            var ouvrage19 = new Ouvrage()
            {
                Titre = "Le peit Chose",
                Auteur = "Alphonse Daudet",
                Exemplaires = 1
            };

            var ouvrage20 = new Ouvrage()
            {
                Titre = "Les lettres de mon moulin",
                Auteur = "Alphonse Daudet",
                Exemplaires = 2
            };

            var ouvrage21 = new Ouvrage()
            {
                Titre = "Tartarin sur les Alpes",
                Auteur = "Alphonse Daudet",
                Exemplaires = 2
            };

            var ouvrage22 = new Ouvrage()
            {
                Titre = "tartarin de Tarascon",
                Auteur = "Alphonse Daudet",
                Exemplaires = 1
            };

            await bibliotheque.Ouvrages.AddRangeAsync(new Ouvrage[] {ouvrage1, ouvrage2, ouvrage3, ouvrage4, ouvrage5, ouvrage6, ouvrage7, ouvrage8,
                                                                     ouvrage9, ouvrage10, ouvrage11, ouvrage12, ouvrage13, ouvrage14, ouvrage15, 
                                                                     ouvrage16, ouvrage17, ouvrage18, ouvrage19, ouvrage20, ouvrage21, ouvrage22
            });


            var reservation1 = new Reservation()
            {
                Utilisateur = michel,
                Ouvrage = ouvrage10
            };

            var reservation2 = new Reservation()
            {
                Utilisateur = michel,
                Ouvrage = ouvrage12
            };

            var reservation3 = new Reservation()
            {
                Utilisateur = felix,
                Ouvrage = ouvrage6
            };

            var reservation4 = new Reservation()
            {
                Utilisateur = anais,
                Ouvrage = ouvrage4
            };

            var reservation5 = new Reservation()
            {
                Utilisateur = kinza,
                Ouvrage = ouvrage20
            };

            var reservation6 = new Reservation()
            {
                Utilisateur = kinza,
                Ouvrage = ouvrage3
            };

            await bibliotheque.Reservations.AddRangeAsync(new Reservation[] { reservation1, reservation2, reservation3, reservation4, reservation5 });

            await bibliotheque.SaveChangesAsync();

        }
    }
}
