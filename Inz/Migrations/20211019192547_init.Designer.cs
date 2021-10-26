﻿// <auto-generated />
using System;
using Inz.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inz.Migrations
{
    [DbContext(typeof(InzDbContext))]
    [Migration("20211019192547_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inz.Entities.Dokument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataWystawienia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataZatwierdzeniaPrzyjecia")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KontrahentId")
                        .HasColumnType("int");

                    b.Property<int?>("KtoWystawilId")
                        .HasColumnType("int");

                    b.Property<int?>("KtoZatwierdzilPrzyjalId")
                        .HasColumnType("int");

                    b.Property<int?>("TypDokumentuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KontrahentId");

                    b.HasIndex("KtoWystawilId");

                    b.HasIndex("KtoZatwierdzilPrzyjalId");

                    b.HasIndex("TypDokumentuId");

                    b.ToTable("Dokument");
                });

            modelBuilder.Entity("Inz.Entities.DokumentProdukt", b =>
                {
                    b.Property<int>("DokumentId")
                        .HasColumnType("int");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.HasKey("DokumentId", "ProduktId");

                    b.HasIndex("ProduktId");

                    b.ToTable("DokumentProdukt");
                });

            modelBuilder.Entity("Inz.Entities.Kategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategoria");
                });

            modelBuilder.Entity("Inz.Entities.Kontrahent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kontrahent");
                });

            modelBuilder.Entity("Inz.Entities.Lokalizacja", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("NumerRegalu")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Lokalizacja");
                });

            modelBuilder.Entity("Inz.Entities.Pracownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pracownik");
                });

            modelBuilder.Entity("Inz.Entities.Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IloscDostepna")
                        .HasColumnType("int");

                    b.Property<int>("IloscObecna")
                        .HasColumnType("int");

                    b.Property<int>("IloscZarezerwowana")
                        .HasColumnType("int");

                    b.Property<int?>("KategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("KodEan")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int?>("LokalizacjaId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("KategoriaId");

                    b.HasIndex("LokalizacjaId");

                    b.ToTable("Produkt");
                });

            modelBuilder.Entity("Inz.Entities.TypDokumentu", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypDokumentu");
                });

            modelBuilder.Entity("Inz.Entities.Dokument", b =>
                {
                    b.HasOne("Inz.Entities.Kontrahent", "Kontrahent")
                        .WithMany()
                        .HasForeignKey("KontrahentId");

                    b.HasOne("Inz.Entities.Pracownik", "KtoWystawil")
                        .WithMany()
                        .HasForeignKey("KtoWystawilId");

                    b.HasOne("Inz.Entities.Pracownik", "KtoZatwierdzilPrzyjal")
                        .WithMany()
                        .HasForeignKey("KtoZatwierdzilPrzyjalId");

                    b.HasOne("Inz.Entities.TypDokumentu", "TypDokumentu")
                        .WithMany()
                        .HasForeignKey("TypDokumentuId");

                    b.Navigation("Kontrahent");

                    b.Navigation("KtoWystawil");

                    b.Navigation("KtoZatwierdzilPrzyjal");

                    b.Navigation("TypDokumentu");
                });

            modelBuilder.Entity("Inz.Entities.DokumentProdukt", b =>
                {
                    b.HasOne("Inz.Entities.Dokument", null)
                        .WithMany("Produkty")
                        .HasForeignKey("DokumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inz.Entities.Produkt", null)
                        .WithMany("Dokumenty")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inz.Entities.Produkt", b =>
                {
                    b.HasOne("Inz.Entities.Kategoria", "Kategoria")
                        .WithMany()
                        .HasForeignKey("KategoriaId");

                    b.HasOne("Inz.Entities.Lokalizacja", "Lokalizacja")
                        .WithMany()
                        .HasForeignKey("LokalizacjaId");

                    b.Navigation("Kategoria");

                    b.Navigation("Lokalizacja");
                });

            modelBuilder.Entity("Inz.Entities.Dokument", b =>
                {
                    b.Navigation("Produkty");
                });

            modelBuilder.Entity("Inz.Entities.Produkt", b =>
                {
                    b.Navigation("Dokumenty");
                });
#pragma warning restore 612, 618
        }
    }
}