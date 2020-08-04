using EFCore.WebAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Data
{
    public class HeroiContext : DbContext
    {
        public DbSet<Heroi> herois { get; set; }
        public DbSet<Batalha> batalhas { get; set; }
        public DbSet<Arma> armas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Password=sa123;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=SABRINA-PC\SQLEXPRESS");
        }

    }
}