using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inz.Entities
{
    public class Dokument
    {
        public int Id { get; set; }
        public virtual TypDokumentu TypDokumentu { get; set; }
        public string NazwaKonrahenta { get; set; }
        public int Ilosc { get; set; }
        public string KodEan { get; set; }

        public virtual List<Produkt> Produkty { get; set; }
    }
}
