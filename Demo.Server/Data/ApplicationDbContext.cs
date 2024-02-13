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

        public DbSet<Demo.Shared.Entidades.Genero> Genero { get; set; } = default!;
        public DbSet<Demo.Shared.Entidades.Actor> Actor { get; set; } = default!;

    }
}
