using Inz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inz.Seeder
{
    public class InzSeeder
    {
        private readonly InzDbContext _dbContext;

        public InzSeeder(InzDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Seed()
        {
            if (this._dbContext.Database.CanConnect())
            {
                if (!this._dbContext.TypDokumentu.Any())
                {
                    IEnumerable<TypDokumentu> typyDokumentow = this.GetTypyDokumentow();
                    this._dbContext.TypDokumentu.AddRange(typyDokumentow);
                    this._dbContext.SaveChanges();

                    if (!this._dbContext.Lokalizacja.Any())
                    {
                        IEnumerable<Lokalizacja> lokalizacje = this.GetLokalizacje();
                        this._dbContext.Lokalizacja.AddRange(lokalizacje);
                        this._dbContext.SaveChanges();
                    }

                    if (!this._dbContext.Kontrahent.Any())
                    {
                        IEnumerable<Kontrahent> kontrahenci = this.GetKontrahenci();
                        this._dbContext.Kontrahent.AddRange(kontrahenci);
                        this._dbContext.SaveChanges();
                    }

                    if (!this._dbContext.Pracownik.Any())
                    {
                        IEnumerable<Pracownik> pracownicy = this.GetPracownicy();
                        this._dbContext.Pracownik.AddRange(pracownicy);
                        this._dbContext.SaveChanges();
                    }

                    if (!this._dbContext.Kategoria.Any())
                    {
                        IEnumerable<Kategoria> kategorie = this.GetKategorie();
                        this._dbContext.Kategoria.AddRange(kategorie);
                        this._dbContext.SaveChanges();
                    }

                    if (!this._dbContext.Dokument.Any())
                    {
                        IEnumerable<Dokument> dokumenty = this.GetDokumenty();
                        this._dbContext.Dokument.AddRange(dokumenty);
                        this._dbContext.SaveChanges();

                        dokumenty = this._dbContext.Dokument.ToList();
                        var referencje = this.GetDokumentyReferencje();
                        int index = 0;
                        foreach (var item in referencje)
                        {
                            var dokument = dokumenty.ElementAt(index);
                            index++;
                            dokument.TypDokumentu = this._dbContext
                                .TypDokumentu.FirstOrDefault(r => r.Id == item.TypDokumentu.Id);
                            dokument.Kontrahent = this._dbContext
                                .Kontrahent.FirstOrDefault(r => r.Id == item.Kontrahent.Id);
                            dokument.KtoWystawil = this._dbContext
                                .Pracownik.FirstOrDefault(r => r.Id == item.KtoWystawil.Id);
                            dokument.KtoZatwierdzilPrzyjal = this._dbContext
                                .Pracownik.FirstOrDefault(r => r.Id == item.KtoZatwierdzilPrzyjal.Id);
                        }
                        this._dbContext.SaveChanges();
                    }

                    if (!this._dbContext.Produkt.Any())
                    {
                        IEnumerable<Produkt> produkty = this.GetProdukty();
                        this._dbContext.Produkt.AddRange(produkty);
                        this._dbContext.SaveChanges();

                        produkty = this._dbContext.Produkt.ToList();
                        var referencje = this.GetProduktyReferencje();
                        int index = 0;
                        foreach (var item in referencje)
                        {
                            var dokument = produkty.ElementAt(index);
                            index++;
                            dokument.Lokalizacja = this._dbContext
                                .Lokalizacja.FirstOrDefault(r => r.Id == item.Lokalizacja.Id);
                            dokument.Kategoria = this._dbContext
                                .Kategoria.FirstOrDefault(r => r.Id == item.Kategoria.Id);
                        }
                        this._dbContext.SaveChanges();
                    }

                    if (!this._dbContext.DokumentProdukt.Any())
                    {
                        IEnumerable<DokumentProdukt> dokumentProdukt = this.GetDokumentProdukt();
                        this._dbContext.DokumentProdukt.AddRange(dokumentProdukt);
                        this._dbContext.SaveChanges();
                    }
                }
            }
        }

        private IEnumerable<Lokalizacja> GetLokalizacje()
        {
            return new List<Lokalizacja>()
            {
                new Lokalizacja()
                {
                    Id = 0,
                    NumerRegalu = 0
                },
                new Lokalizacja()
                {
                    Id = 1,
                    NumerRegalu = 1
                },
                new Lokalizacja()
                {
                    Id = 2,
                    NumerRegalu = 2
                },
                new Lokalizacja()
                {
                    Id = 3,
                    NumerRegalu = 3
                },
                new Lokalizacja()
                {
                    Id = 4,
                    NumerRegalu = 4
                },
                new Lokalizacja()
                {
                    Id = 5,
                    NumerRegalu = 5
                },
                new Lokalizacja()
                {
                    Id = 6,
                    NumerRegalu = 6
                },
                new Lokalizacja()
                {
                    Id = 7,
                    NumerRegalu = 7
                },
                new Lokalizacja()
                {
                    Id = 8,
                    NumerRegalu = 8
                },
                new Lokalizacja()
                {
                    Id = 9,
                    NumerRegalu = 9
                },
                new Lokalizacja()
                {
                    Id = 10,
                    NumerRegalu = 10
                },
                new Lokalizacja()
                {
                    Id = 11,
                    NumerRegalu = 11
                },
                new Lokalizacja()
                {
                    Id = 12,
                    NumerRegalu = 12
                },
                new Lokalizacja()
                {
                    Id = 13,
                    NumerRegalu = 13
                },
                new Lokalizacja()
                {
                    Id = 14,
                    NumerRegalu = 14
                },
                new Lokalizacja()
                {
                    Id = 15,
                    NumerRegalu = 15
                },
                new Lokalizacja()
                {
                    Id = 16,
                    NumerRegalu = 16
                },
                new Lokalizacja()
                {
                    Id = 17,
                    NumerRegalu = 17
                },
                new Lokalizacja()
                {
                    Id = 18,
                    NumerRegalu = 18
                },
                new Lokalizacja()
                {
                    Id = 19,
                    NumerRegalu = 19
                },
                new Lokalizacja()
                {
                    Id = 20,
                    NumerRegalu = 20
                }
            };
        }

        private IEnumerable<TypDokumentu> GetTypyDokumentow()
        {
            return new List<TypDokumentu>()
            {
                new TypDokumentu()
                {
                    Id = 1,
                    Nazwa = null
                },
                new TypDokumentu()
                {
                    Id = 2,
                    Nazwa = "WZ"
                },
                new TypDokumentu()
                {
                    Id = 3,
                    Nazwa = "RW"
                },
                new TypDokumentu()
                {
                    Id = 4,
                    Nazwa = "PW"
                },
                new TypDokumentu()
                {
                    Id = 5,
                    Nazwa = "MMW"
                },
                new TypDokumentu()
                {
                    Id = 6,
                    Nazwa = "MMP"
                },
                new TypDokumentu()
                {
                    Id = 7,
                    Nazwa = "ZK"
                }
            };
        }

        private IEnumerable<Kontrahent> GetKontrahenci()
        {
            return new List<Kontrahent>()
            {
                new Kontrahent()
                {
                    Nazwa = "Biedronka"
                },
                new Kontrahent()
                {
                    Nazwa = "Żabka"
                },
                new Kontrahent()
                {
                    Nazwa = "Kaufland"
                },
                new Kontrahent()
                {
                    Nazwa = "Netto"
                },
                new Kontrahent()
                {
                    Nazwa = "Dino"
                },
                new Kontrahent()
                {
                    Nazwa = "Lewiatan"
                },
                new Kontrahent()
                {
                    Nazwa = null
                }
            };
        }

        private IEnumerable<Pracownik> GetPracownicy()
        {
            return new List<Pracownik>()
            {
                new Pracownik()
                {
                    Imie = "Jan",
                    Nazwisko = "Naj"
                },
                new Pracownik()
                {
                    Imie = "Denis",
                    Nazwisko = "Sined"
                },
                new Pracownik()
                {
                    Imie = "Bartosz",
                    Nazwisko = "Zsotrab"
                },
                new Pracownik()
                {
                    Imie = "Daniel",
                    Nazwisko = "Leinad"
                },
                new Pracownik()
                {
                    Imie = "Tomasz",
                    Nazwisko = "Zsamot"
                },
                new Pracownik()
                {
                    Imie = null,
                    Nazwisko = null
                }
            };
        }

        private IEnumerable<Kategoria> GetKategorie()
        {
            return new List<Kategoria>()
            {
                new Kategoria()
                {
                    Nazwa = "Drewno"
                },
                new Kategoria()
                {
                    Nazwa = "Art. spożywcze"
                },
                new Kategoria()
                {
                    Nazwa = "Art. budowlane"
                },
                new Kategoria()
                {
                    Nazwa = "Chemia"
                },
                new Kategoria()
                {
                    Nazwa = "Farba"
                },
                new Kategoria()
                {
                    Nazwa = null
                }
            };
        }

        private IEnumerable<Dokument> GetDokumenty()
        {
            return new List<Dokument>()
            {
                new Dokument()
                {
                    DataWystawienia = new DateTime(2021, 10, 09),
                    DataZatwierdzeniaPrzyjecia = new DateTime(2021, 10, 09)
                },
                new Dokument()
                {
                    DataWystawienia = new DateTime(2021, 10, 10),
                    DataZatwierdzeniaPrzyjecia = new DateTime(2021, 10, 10)
                },
                new Dokument()
                {
                    DataWystawienia = new DateTime(2021, 11, 10),
                    DataZatwierdzeniaPrzyjecia = new DateTime(2021, 11, 10)
                },
                new Dokument()
                {
                    DataWystawienia = new DateTime(2022, 10, 10),
                    DataZatwierdzeniaPrzyjecia = new DateTime(2022, 10, 10)
                },
                new Dokument()
                {
                    DataWystawienia = new DateTime(2023, 10, 10),
                    DataZatwierdzeniaPrzyjecia = new DateTime(2023, 10, 10)
                }
            };
        }

        private IEnumerable<Dokument> GetDokumentyReferencje()
        {
            var dokumentyList = this.GetDokumenty();
            var dokumentyArray = dokumentyList.ToArray();
            dokumentyArray[0].TypDokumentu = new TypDokumentu()
            {
                Id = 1
            };
            dokumentyArray[0].Kontrahent = new Kontrahent()
            {
                Id = 1
            };
            dokumentyArray[0].KtoWystawil = new Pracownik()
            {
                Id = 1
            };
            dokumentyArray[0].KtoZatwierdzilPrzyjal = new Pracownik()
            {
                Id = 1
            };

            dokumentyArray[1].TypDokumentu = new TypDokumentu()
            {
                Id = 2
            };
            dokumentyArray[1].Kontrahent = new Kontrahent()
            {
                Id = 2
            };
            dokumentyArray[1].KtoWystawil = new Pracownik()
            {
                Id = 2
            };
            dokumentyArray[1].KtoZatwierdzilPrzyjal = new Pracownik()
            {
                Id = 2
            };

            dokumentyArray[2].TypDokumentu = new TypDokumentu()
            {
                Id = 3
            };
            dokumentyArray[2].Kontrahent = new Kontrahent()
            {
                Id = 3
            };
            dokumentyArray[2].KtoWystawil = new Pracownik()
            {
                Id = 3
            };
            dokumentyArray[2].KtoZatwierdzilPrzyjal = new Pracownik()
            {
                Id = 3
            };

            dokumentyArray[3].TypDokumentu = new TypDokumentu()
            {
                Id = 4
            };
            dokumentyArray[3].Kontrahent = new Kontrahent()
            {
                Id = 4
            };
            dokumentyArray[3].KtoWystawil = new Pracownik()
            {
                Id = 4
            };
            dokumentyArray[3].KtoZatwierdzilPrzyjal = new Pracownik()
            {
                Id = 4
            };

            dokumentyArray[4].TypDokumentu = new TypDokumentu()
            {
                Id = 2
            };
            dokumentyArray[4].Kontrahent = new Kontrahent()
            {
                Id = 2
            };
            dokumentyArray[4].KtoWystawil = new Pracownik()
            {
                Id = 2
            };
            dokumentyArray[4].KtoZatwierdzilPrzyjal = new Pracownik()
            {
                Id = 2
            };

            return dokumentyArray.ToList();
        }

        private IEnumerable<Produkt> GetProdukty()
        {
            return new List<Produkt>()
            {
                new Produkt()
                {
                    Nazwa = "Produkt 1",
                    IloscObecna = 200,
                    IloscZarezerwowana = 100,
                    IloscDostepna = 100,
                    KodEan = "123"
                },
                new Produkt()
                {
                    Nazwa = "Produkt 2",
                    IloscObecna = 50,
                    IloscZarezerwowana = 10,
                    IloscDostepna = 40,
                    KodEan = "456"
                },
                new Produkt()
                {
                    Nazwa = "Produkt 3",
                    IloscObecna = 0,
                    IloscZarezerwowana = 0,
                    IloscDostepna = 0,
                    KodEan = ""
                },
                new Produkt()
                {
                    Nazwa = "Produkt 4",
                    IloscObecna = 2,
                    IloscZarezerwowana = 1,
                    IloscDostepna = 1,
                    KodEan = "789"
                },
                new Produkt()
                {
                    Nazwa = "Produkt 5",
                    IloscObecna = 5,
                    IloscZarezerwowana = 1,
                    IloscDostepna = 4,
                    KodEan = "11111111"
                }
            };
        }

        private IEnumerable<Produkt> GetProduktyReferencje()
        {
            var produktyList = this.GetProdukty();
            var produktyArray = produktyList.ToArray();
            produktyArray[0].Lokalizacja = new Lokalizacja()
            {
                Id = 1
            };
            produktyArray[0].Kategoria = new Kategoria()
            {
                Id = 1
            };

            produktyArray[1].Lokalizacja = new Lokalizacja()
            {
                Id = 2
            };
            produktyArray[1].Kategoria = new Kategoria()
            {
                Id = 2
            };

            produktyArray[2].Lokalizacja = new Lokalizacja()
            {
                Id = 0
            };
            produktyArray[2].Kategoria = new Kategoria()
            {
                Id = 0
            };

            produktyArray[3].Lokalizacja = new Lokalizacja()
            {
                Id = 10
            };
            produktyArray[3].Kategoria = new Kategoria()
            {
                Id = 3
            };

            produktyArray[4].Lokalizacja = new Lokalizacja()
            {
                Id = 5
            };
            produktyArray[4].Kategoria = new Kategoria()
            {
                Id = 5
            };

            return produktyArray.ToList();
        }

        private IEnumerable<DokumentProdukt> GetDokumentProdukt()
        {
            return new List<DokumentProdukt>()
            {
                new DokumentProdukt()
                {
                    DokumentId = 1,
                    ProduktId = 1
                },
                new DokumentProdukt()
                {
                    DokumentId = 2,
                    ProduktId = 2
                },
                new DokumentProdukt()
                {
                    DokumentId = 2,
                    ProduktId = 3
                },
                new DokumentProdukt()
                {
                    DokumentId = 3,
                    ProduktId = 4
                },
                new DokumentProdukt()
                {
                    DokumentId = 5,
                    ProduktId = 5
                }
            };
        }
    }
}
