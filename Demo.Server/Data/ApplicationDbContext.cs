using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo.Shared.Entidades;

namespace Demo.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GeneroPelicula>().HasKey(x => new { x.GeneroId, x.PeliculaId });
            modelBuilder.Entity<PeliculaActor>().HasKey(x => new { x.ActorId, x.PeliculaId });
        }


        public DbSet<Genero> Genero { get; set; } = default!;
        public DbSet<Actor> Actor { get; set; } = default!;
        public DbSet<Pelicula> Pelicula { get; set; } = default!;

        public DbSet<GeneroPelicula> GenerosPeliculas { get; set; } = default!;
        public DbSet<PeliculaActor> PeliculasActores { get; set; } = default!;
        public DbSet<VotoPelicula> VotosPeliculas { get; set; } = default!;

    }
}
