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
                if (!this._dbContext.Lokalizacja.Any())
                {
                    IEnumerable<Lokalizacja> lokalizacje = this.GetLokalizacje();
                    this._dbContext.Lokalizacja.AddRange(lokalizacje);
                    this._dbContext.SaveChanges();
                }

                if (!this._dbContext.TypDokumentu.Any())
                {
                    IEnumerable<TypDokumentu> typyDokumentow = this.GetTypyDokumentow();
                    this._dbContext.TypDokumentu.AddRange(typyDokumentow);
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
                    }
                    this._dbContext.SaveChanges();
                }

                if (!this._dbContext.Przyjecie.Any())
                {
                    IEnumerable<Przyjecie> przyjecia = this.GetPrzyjecia();
                    this._dbContext.Przyjecie.AddRange(przyjecia);
                    this._dbContext.SaveChanges();
                }

                if (!this._dbContext.DokumentProdukt.Any())
                {
                    IEnumerable<DokumentProdukt> dokumentProdukt = this.GetDokumentProdukt();
                    this._dbContext.DokumentProdukt.AddRange(dokumentProdukt);
                    this._dbContext.SaveChanges();
                }

                if (!this._dbContext.ProduktPrzyjecie.Any())
                {
                    IEnumerable<ProduktPrzyjecie> produktPrzyjecie = this.GetProduktPrzyjecie();
                    this._dbContext.ProduktPrzyjecie.AddRange(produktPrzyjecie);
                    this._dbContext.SaveChanges();
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
                    Opis = null
                },
                new TypDokumentu()
                {
                    Id = 2,
                    Opis = "WZ"
                },
                new TypDokumentu()
                {
                    Id = 3,
                    Opis = "RW"
                },
                new TypDokumentu()
                {
                    Id = 4,
                    Opis = "PW"
                },
                new TypDokumentu()
                {
                    Id = 5,
                    Opis = "MMW"
                },
                new TypDokumentu()
                {
                    Id = 6,
                    Opis = "MMP"
                },
                new TypDokumentu()
                {
                    Id = 7,
                    Opis = "ZK"
                }
            };
        }

        private IEnumerable<Dokument> GetDokumenty()
        {
            return new List<Dokument>()
            {
                new Dokument()
                {
                    NazwaKonrahenta = "Biedronka",
                    Ilosc = 1,
                    KodEan = "1"
                },
                new Dokument()
                {
                    NazwaKonrahenta = "Żabka",
                    Ilosc = 2,
                    KodEan = "2"
                },
                new Dokument()
                {
                    NazwaKonrahenta = "Kaufland",
                    Ilosc = 3,
                    KodEan = "3"
                },
                new Dokument()
                {
                    NazwaKonrahenta = "Netto",
                    Ilosc = 4,
                    KodEan = "4"
                },
                new Dokument()
                {
                    NazwaKonrahenta = "Dino",
                    Ilosc = 5,
                    KodEan = "5"
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
            dokumentyArray[1].TypDokumentu = new TypDokumentu()
            {
                Id = 2
            };
            dokumentyArray[2].TypDokumentu = new TypDokumentu()
            {
                Id = 3
            };
            dokumentyArray[3].TypDokumentu = new TypDokumentu()
            {
                Id = 4
            };
            dokumentyArray[4].TypDokumentu = new TypDokumentu()
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
                    Cena = 59,
                    KodEan = "123",
                    Kategoria = "Drewno"
                },
                new Produkt()
                {
                    Nazwa = "Produkt 2",
                    IloscObecna = 50,
                    IloscZarezerwowana = 10,
                    IloscDostepna = 40,
                    Cena = 2,
                    KodEan = "456",
                    Kategoria = "Art. spożywcze"
                },
                new Produkt()
                {
                    Nazwa = "Produkt 3",
                    IloscObecna = 0,
                    IloscZarezerwowana = 0,
                    IloscDostepna = 0,
                    Cena = 0,
                    KodEan = "",
                    Kategoria = "Brak"
                },
                new Produkt()
                {
                    Nazwa = "Produkt 4",
                    IloscObecna = 2,
                    IloscZarezerwowana = 1,
                    IloscDostepna = 1,
                    Cena = 10000,
                    KodEan = "789",
                    Kategoria = "Art. budowlane"
                },
                new Produkt()
                {
                    Nazwa = "Produkt 5",
                    IloscObecna = 5,
                    IloscZarezerwowana = 1,
                    IloscDostepna = 4,
                    Cena = 1002,
                    KodEan = "11111111",
                    Kategoria = "Chemia"
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
            produktyArray[1].Lokalizacja = new Lokalizacja()
            {
                Id = 2
            };
            produktyArray[2].Lokalizacja = new Lokalizacja()
            {
                Id = 0
            };
            produktyArray[3].Lokalizacja = new Lokalizacja()
            {
                Id = 10
            };
            produktyArray[4].Lokalizacja = new Lokalizacja()
            {
                Id = 5
            };
            return produktyArray.ToList();
        }

        private IEnumerable<Przyjecie> GetPrzyjecia()
        {
            return new List<Przyjecie>()
            {
                new Przyjecie()
                {
                    DataPrzyjazdu = new DateTime(2021, 10, 09),
                    DataWypakowania = new DateTime(2021, 10, 09),
                    KtoWystawil = "Jan Kowalski",
                    KtoObsluguje = "Zbigniew Stonoga"
                },
                new Przyjecie()
                {
                    DataPrzyjazdu = new DateTime(2021, 10, 09),
                    DataWypakowania = new DateTime(2021, 10, 09),
                    KtoWystawil = "Jan Kowalski",
                    KtoObsluguje = "Zbigniew Stonoga"
                }
            };
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

        private IEnumerable<ProduktPrzyjecie> GetProduktPrzyjecie()
        {
            return new List<ProduktPrzyjecie>()
            {
                new ProduktPrzyjecie()
                {
                    ProduktId = 1,
                    PrzyjecieId = 1
                },
                new ProduktPrzyjecie()
                {
                    ProduktId = 2,
                    PrzyjecieId = 1
                },
                new ProduktPrzyjecie()
                {
                    ProduktId = 3,
                    PrzyjecieId = 2
                },
                new ProduktPrzyjecie()
                {
                    ProduktId = 4,
                    PrzyjecieId = 2
                },
                new ProduktPrzyjecie()
                {
                    ProduktId = 5,
                    PrzyjecieId = 2
                }
            };
        }
    }
}
