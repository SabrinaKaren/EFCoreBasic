using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain;

namespace EFCore.Repository
{
    public class HeroiContext : DbContext
    {

        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options)
        {
        }

        public DbSet<Heroi> herois { get; set; }
        public DbSet<Batalha> batalhas { get; set; }
        public DbSet<Arma> armas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                entity.HasKey(e => new { e.batalhaId, e.heroiId });
            });
        }

    }
}