using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Inz.Entities;

namespace Inz.Models
{
    public class CreateProduktDto
    {
        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; }
        public int IloscObecna { get; set; }
        public int IloscZarezerwowana { get; set; }
        public int IloscDostepna { get; set; }
        [Required]
        [MaxLength(13)]
        public string KodEan { get; set; }
        public virtual Lokalizacja Lokalizacja { get; set; }
        public virtual Kategoria Kategoria { get; set; }

        public virtual List<DokumentProdukt> Dokumenty { get; set; }
    }
}
