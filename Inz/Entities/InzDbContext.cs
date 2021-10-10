﻿using System;
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
        public DbSet<DokumentProdukt> DokumentProdukt { get; set; }
        public DbSet<Lokalizacja> Lokalizacja { get; set; }
        public DbSet<Produkt> Produkt { get; set; }
        public DbSet<ProduktPrzyjecie> ProduktPrzyjecie { get; set; }
        public DbSet<Przyjecie> Przyjecie { get; set; }
        public DbSet<TypDokumentu> TypDokumentu { get; set; }

        //tutaj możemy dodać właściwości kolumn
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

            modelBuilder.Entity<DokumentProdukt>()
                .HasKey(c => new { c.DokumentId, c.ProduktId });

            modelBuilder.Entity<ProduktPrzyjecie>()
                .HasKey(c => new { c.ProduktId, c.PrzyjecieId });

            modelBuilder.Entity<Produkt>()
                .Property(r => r.Nazwa)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Produkt>()
                .Property(r => r.Cena)
                .IsRequired();

            modelBuilder.Entity<Produkt>()
                .Property(r => r.KodEan)
                .IsRequired()
                .HasMaxLength(13);

            modelBuilder.Entity<TypDokumentu>()
                .Property(r => r.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Lokalizacja>()
                .Property(r => r.Id)
                .ValueGeneratedNever();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
