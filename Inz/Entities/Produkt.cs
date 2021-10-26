using System;
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
        public string KodEan { get; set; }
        public virtual Lokalizacja Lokalizacja { get; set; }
        public virtual Kategoria Kategoria { get; set; }

        public virtual List<DokumentProdukt> Dokumenty { get; set; }
    }
}
