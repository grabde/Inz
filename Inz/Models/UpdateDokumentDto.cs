using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Inz.Entities;

namespace Inz.Models
{
    public class UpdateDokumentDto
    {
        public virtual TypDokumentu TypDokumentu { get; set; }
        public virtual Kontrahent Kontrahent { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime DataZatwierdzeniaPrzyjecia { get; set; }
        public virtual Pracownik KtoWystawil { get; set; }
        public virtual Pracownik KtoZatwierdzilPrzyjal { get; set; }

        public virtual List<DokumentProdukt> Produkty { get; set; }
    }
}
