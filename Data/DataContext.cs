using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using RpgAPI.Models;
using RpgAPI.Utils;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //
        }

        public DbSet<Usuario> TB_USUARIOS { get; set; }
        public DbSet<Arma> TB_ARMAS { get; set; }
        public DbSet<Habilidade> TB_HABILIDADES { get; set; }
        public DbSet<Personagem> TB_PERSONAGENS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Arma>().ToTable("TB_ARMAS");
            modelBuilder.Entity<Arma>().HasData
            (
                new Arma() { Id = 1, Nome = "Espada Kaos", Dano = 48, PersonagemId = 1 },
                new Arma() { Id = 2, Nome = "Arco iNOE", Dano = 21, PersonagemId = 4 },
                new Arma() { Id = 3, Nome = "Adaga Heian", Dano = 69, PersonagemId = 8 },
                new Arma() { Id = 4, Nome = "Amuleto KoIs Amaldiçoado", Dano = 2, PersonagemId = 2 },
                new Arma() { Id = 5, Nome = "Olhos ReinKiri", Dano = 12, PersonagemId = 7 }
            );

            modelBuilder.Entity<Habilidade>().ToTable("TB_HABILIDADES");
            modelBuilder.Entity<Habilidade>()
                .HasData
            (
                new Habilidade(){Id = 1, Nome = "Fogo amaldiçoado", Dano = 23},
                new Habilidade(){Id = 2, Nome = "Chuva ContraTempoária", Dano = 67},
                new Habilidade(){Id = 3, Nome = "Corte Simples | Novo estilo da Sombra", Dano = 16},
                new Habilidade(){Id = 4, Nome = "Gás Tóxico | MicroFissura"},
                new Habilidade(){Id = 5, Nome = "Pico de força Espartana"},
                new Habilidade(){Id = 6, Nome = "Anomalia Temporal"}
            );

            modelBuilder.Entity<PersonagemHabilidade>().ToTable("TB_PERSONAGENS_HABILIDADES");
            modelBuilder.Entity<PersonagemHabilidade>()
                .HasKey(ph => new {ph.PersonagemId, ph.HabilidadeId});
            modelBuilder.Entity<PersonagemHabilidade>()
                .HasData
            (
                new PersonagemHabilidade() {PersonagemId = 1, HabilidadeId = 2},
                new PersonagemHabilidade() {PersonagemId = 1, HabilidadeId = 1},
                new PersonagemHabilidade() {PersonagemId = 1, HabilidadeId = 3},
                new PersonagemHabilidade() {PersonagemId = 1, HabilidadeId = 4},
                new PersonagemHabilidade() {PersonagemId = 1, HabilidadeId = 5},
                new PersonagemHabilidade() {PersonagemId = 2, HabilidadeId = 1},
                new PersonagemHabilidade() {PersonagemId = 2, HabilidadeId = 3},
                new PersonagemHabilidade() {PersonagemId = 3, HabilidadeId = 1},
                new PersonagemHabilidade() {PersonagemId = 3, HabilidadeId = 3},
                new PersonagemHabilidade() {PersonagemId = 3, HabilidadeId = 2},
                new PersonagemHabilidade() {PersonagemId = 4, HabilidadeId = 5},
                new PersonagemHabilidade() {PersonagemId = 5, HabilidadeId = 1},
                new PersonagemHabilidade() {PersonagemId = 5, HabilidadeId = 2},
                new PersonagemHabilidade() {PersonagemId = 5, HabilidadeId = 4}
            );

            //Relacionamento Arma e Personagem One for One
            modelBuilder.Entity<Personagem>()
            .HasOne(e => e.Arma)
            .WithOne(e => e.Personagem)
            .HasForeignKey<Arma>(e => e.PersonagemId)
            .IsRequired();


            //Criação Usuario | One for Many
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Personagens)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .IsRequired(false);

            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "admin";
            user.Email = "seuEmail@email.com";
            user.Latitude = -23.5200241;
            user.Longitude = -56.596498;

            modelBuilder.Entity<Usuario>().HasData(user);

            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Player");


            modelBuilder.Entity<Personagem>().ToTable("TB_PERSONAGENS");
            modelBuilder.Entity<Personagem>().HasData
            (
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = ClasseEnum.Cavaleiro, UsuarioId = 1 },
            new Personagem() { Id = 2, Nome = "Sam", PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Cavaleiro, UsuarioId = 1 },
            new Personagem() { Id = 3, Nome = "Hobbit", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe = ClasseEnum.Cavaleiro, UsuarioId = 1 },
            new Personagem() { Id = 4, Nome = "Artur", PontosVida = 120, Forca = 28, Defesa = 35, Inteligencia = 25, Classe = ClasseEnum.Cavaleiro, UsuarioId = 1 },
            new Personagem() { Id = 5, Nome = "Lancelote", PontosVida = 115, Forca = 30, Defesa = 32, Inteligencia = 24, Classe = ClasseEnum.Cavaleiro, UsuarioId = 1 },
            new Personagem() { Id = 6, Nome = "Gawain", PontosVida = 125, Forca = 26, Defesa = 30, Inteligencia = 22, Classe = ClasseEnum.Cavaleiro, UsuarioId = 1 },
            new Personagem() { Id = 7, Nome = "Bedivere", PontosVida = 110, Forca = 25, Defesa = 28, Inteligencia = 26, Classe = ClasseEnum.Cavaleiro, UsuarioId = 1 },
            new Personagem() { Id = 8, Nome = "Gandalf", PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe = ClasseEnum.Mago, UsuarioId = 1 },
            new Personagem() { Id = 9, Nome = "Merlin", PontosVida = 85, Forca = 14, Defesa = 15, Inteligencia = 45, Classe = ClasseEnum.Mago, UsuarioId = 1 },
            new Personagem() { Id = 10, Nome = "Saruman", PontosVida = 90, Forca = 16, Defesa = 14, Inteligencia = 48, Classe = ClasseEnum.Mago, UsuarioId = 1 },
            new Personagem() { Id = 11, Nome = "Morgana", PontosVida = 88, Forca = 13, Defesa = 16, Inteligencia = 50, Classe = ClasseEnum.Mago, UsuarioId = 1 },
            new Personagem() { Id = 12, Nome = "Radagast", PontosVida = 92, Forca = 15, Defesa = 13, Inteligencia = 42, Classe = ClasseEnum.Mago, UsuarioId = 1 },
            new Personagem() { Id = 13, Nome = "Galadriel", PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe = ClasseEnum.Clerigo, UsuarioId = 1 },
            new Personagem() { Id = 14, Nome = "Celeborn", PontosVida = 100, Forca = 21, Defesa = 13, Inteligencia = 34, Classe = ClasseEnum.Clerigo, UsuarioId = 1 },
            new Personagem() { Id = 15, Nome = "Elara", PontosVida = 105, Forca = 18, Defesa = 24, Inteligencia = 40, Classe = ClasseEnum.Clerigo, UsuarioId = 1 },
            new Personagem() { Id = 16, Nome = "Isolda", PontosVida = 100, Forca = 16, Defesa = 26, Inteligencia = 38, Classe = ClasseEnum.Clerigo, UsuarioId = 1 },
            new Personagem() { Id = 17, Nome = "Taliesin", PontosVida = 102, Forca = 17, Defesa = 22, Inteligencia = 41, Classe = ClasseEnum.Clerigo, UsuarioId = 1 },
            new Personagem() { Id = 18, Nome = "Morgaine", PontosVida = 108, Forca = 19, Defesa = 25, Inteligencia = 39, Classe = ClasseEnum.Clerigo, UsuarioId = 1 },
            new Personagem() { Id = 19, Nome = "Karsen", PontosVida = 110, Forca = 32, Defesa = 100, Inteligencia = 80, Classe = ClasseEnum.Espadachim, UsuarioId = 1 },
            new Personagem() { Id = 20, Nome = "Conan", PontosVida = 130, Forca = 35, Defesa = 20, Inteligencia = 18, Classe = ClasseEnum.Espadachim, UsuarioId = 1 },
            new Personagem() { Id = 21, Nome = "Beowulf", PontosVida = 128, Forca = 33, Defesa = 22, Inteligencia = 19, Classe = ClasseEnum.Espadachim, UsuarioId = 1 },
            new Personagem() { Id = 22, Nome = "Sigurd", PontosVida = 125, Forca = 31, Defesa = 24, Inteligencia = 20, Classe = ClasseEnum.Espadachim, UsuarioId = 1 },
            new Personagem() { Id = 23, Nome = "Heracles", PontosVida = 135, Forca = 36, Defesa = 19, Inteligencia = 17, Classe = ClasseEnum.Espadachim, UsuarioId = 1 },
            new Personagem() { Id = 24, Nome = "Robin", PontosVida = 95, Forca = 19, Defesa = 18, Inteligencia = 35, Classe = ClasseEnum.Arqueiro, UsuarioId = 1 },
            new Personagem() { Id = 25, Nome = "Sofiz", PontosVida = 100, Forca = 15, Defesa = 20, Inteligencia = 60, Classe = ClasseEnum.Arqueiro, UsuarioId = 1 },
            new Personagem() { Id = 26, Nome = "Legolas", PontosVida = 98, Forca = 21, Defesa = 16, Inteligencia = 32, Classe = ClasseEnum.Arqueiro, UsuarioId = 1 },
            new Personagem() { Id = 27, Nome = "Artemis", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 38, Classe = ClasseEnum.Arqueiro, UsuarioId = 1 },
            new Personagem() { Id = 28, Nome = "Hawkeye", PontosVida = 93, Forca = 18, Defesa = 19, Inteligencia = 36, Classe = ClasseEnum.Arqueiro, UsuarioId = 1 },
            new Personagem() { Id = 29, Nome = "Darthur", PontosVida = 96, Forca = 22, Defesa = 15, Inteligencia = 34, Classe = ClasseEnum.Arqueiro, UsuarioId = 1 }
            );
        } //Fim metodo onmodelcreate

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }

    }
}