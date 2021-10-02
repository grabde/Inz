﻿// <auto-generated />
using System;
using Inz.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inz.Migrations
{
    [DbContext(typeof(InzDbContext))]
    partial class InzDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DokumentProdukt", b =>
                {
                    b.Property<int>("DokumentyId")
                        .HasColumnType("int");

                    b.Property<int>("ProduktyId")
                        .HasColumnType("int");

                    b.HasKey("DokumentyId", "ProduktyId");

                    b.HasIndex("ProduktyId");

                    b.ToTable("DokumentProdukt");
                });

            modelBuilder.Entity("Inz.Entities.Dokument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<string>("KodEan")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("NazwaKonrahenta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.Property<int?>("TypDokumentuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypDokumentuId");

                    b.ToTable("Dokument");
                });

            modelBuilder.Entity("Inz.Entities.Lokalizacja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumerRegalu")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Lokalizacja");
                });

            modelBuilder.Entity("Inz.Entities.Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<int>("IloscDostepna")
                        .HasColumnType("int");

                    b.Property<int>("IloscObecna")
                        .HasColumnType("int");

                    b.Property<int>("IloscZarezerwowana")
                        .HasColumnType("int");

                    b.Property<string>("Kategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodEan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LokalizacjaId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LokalizacjaId");

                    b.ToTable("Produkt");
                });

            modelBuilder.Entity("Inz.Entities.Przyjecie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPrzyjazdu")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataWypakowania")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoObsluguje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWystawil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Przyjecie");
                });

            modelBuilder.Entity("Inz.Entities.TypDokumentu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypDokumentu");
                });

            modelBuilder.Entity("ProduktPrzyjecie", b =>
                {
                    b.Property<int>("ProduktyId")
                        .HasColumnType("int");

                    b.Property<int>("PrzyjeciaId")
                        .HasColumnType("int");

                    b.HasKey("ProduktyId", "PrzyjeciaId");

                    b.HasIndex("PrzyjeciaId");

                    b.ToTable("ProduktPrzyjecie");
                });

            modelBuilder.Entity("DokumentProdukt", b =>
                {
                    b.HasOne("Inz.Entities.Dokument", null)
                        .WithMany()
                        .HasForeignKey("DokumentyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inz.Entities.Produkt", null)
                        .WithMany()
                        .HasForeignKey("ProduktyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inz.Entities.Dokument", b =>
                {
                    b.HasOne("Inz.Entities.TypDokumentu", "TypDokumentu")
                        .WithMany("Dokumenty")
                        .HasForeignKey("TypDokumentuId");

                    b.Navigation("TypDokumentu");
                });

            modelBuilder.Entity("Inz.Entities.Produkt", b =>
                {
                    b.HasOne("Inz.Entities.Lokalizacja", "Lokalizacja")
                        .WithMany("Produkty")
                        .HasForeignKey("LokalizacjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lokalizacja");
                });

            modelBuilder.Entity("ProduktPrzyjecie", b =>
                {
                    b.HasOne("Inz.Entities.Produkt", null)
                        .WithMany()
                        .HasForeignKey("ProduktyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inz.Entities.Przyjecie", null)
                        .WithMany()
                        .HasForeignKey("PrzyjeciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inz.Entities.Lokalizacja", b =>
                {
                    b.Navigation("Produkty");
                });

            modelBuilder.Entity("Inz.Entities.TypDokumentu", b =>
                {
                    b.Navigation("Dokumenty");
                });
#pragma warning restore 612, 618
        }
    }
}
