using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inz.Entities
{
    public class InzDbContext : DbContext
    {
        private string _connectionString = "Server=ZDG;Database=InzDb;Trusted_Connection=True;";

        public DbSet<Dokument> Dokument { get; set; }
        public DbSet<Lokalizacja> Lokalizacja { get; set; }
        public DbSet<Produkt> Produkt { get; set; }
        public DbSet<Przyjecie> Przyjecie { get; set; }
        public DbSet<TypDokumentu> TypDokumentu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dokument>()
                .Property(r => r.NazwaKonrahenta)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Dokument>()
                .Property(r => r.Ilosc)
                .IsRequired();

            modelBuilder.Entity<Dokument>()
                .Property(r => r.KodEan)
                .IsRequired()
                .HasMaxLength(13);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
