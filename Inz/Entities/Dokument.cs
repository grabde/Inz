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
        public virtual Kontrahent Kontrahent { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime DataZatwierdzeniaPrzyjecia { get; set; }
        public virtual Pracownik KtoWystawil { get; set; }
        public virtual Pracownik KtoZatwierdzilPrzyjal { get; set; }

        public virtual List<DokumentProdukt> Produkty { get; set; }
    }
}
