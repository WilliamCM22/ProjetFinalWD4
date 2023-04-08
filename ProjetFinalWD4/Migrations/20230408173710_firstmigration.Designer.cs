﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetFinalWD4.Data;

#nullable disable

namespace ProjetFinalWD4.Migrations
{
    [DbContext(typeof(Bibliotheque))]
    [Migration("20230408173710_firstmigration")]
    partial class firstmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetFinalWD4.Models.Ouvrage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Auteur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Exemplaires")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Ouvrages");
                });

            modelBuilder.Entity("ProjetFinalWD4.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("OuvrageID")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OuvrageID");

                    b.HasIndex("UtilisateurID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ProjetFinalWD4.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProjetFinalWD4.Models.Utilisateur", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Administrateur")
                        .HasColumnType("bit");

                    b.Property<string>("Courriel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Langue")
                        .HasColumnType("int");

                    b.Property<byte[]>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("RoleUtilisateur", b =>
                {
                    b.Property<int>("RolesID")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateursID")
                        .HasColumnType("int");

                    b.HasKey("RolesID", "UtilisateursID");

                    b.HasIndex("UtilisateursID");

                    b.ToTable("RoleUtilisateur");
                });

            modelBuilder.Entity("ProjetFinalWD4.Models.Reservation", b =>
                {
                    b.HasOne("ProjetFinalWD4.Models.Ouvrage", "Ouvrage")
                        .WithMany("Reservations")
                        .HasForeignKey("OuvrageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetFinalWD4.Models.Utilisateur", "Utilisateur")
                        .WithMany("Reservations")
                        .HasForeignKey("UtilisateurID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ouvrage");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("RoleUtilisateur", b =>
                {
                    b.HasOne("ProjetFinalWD4.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetFinalWD4.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UtilisateursID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetFinalWD4.Models.Ouvrage", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("ProjetFinalWD4.Models.Utilisateur", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
