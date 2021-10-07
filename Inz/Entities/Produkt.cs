﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inz.Entities
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int IloscObecna { get; set; }
        public int IloscZarezerwowana { get; set; }
        public int IloscDostepna { get; set; }
        public double Cena { get; set; }
        public string KodEan { get; set; }
        public string Kategoria { get; set; }

        public virtual List<DokumentProdukt> Dokumenty { get; set; }

        public virtual List<ProduktPrzyjecie> Przyjecia { get; set; }

        public virtual Lokalizacja Lokalizacja { get; set; }
    }
}
