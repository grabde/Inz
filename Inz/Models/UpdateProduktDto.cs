using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Inz.Entities;

namespace Inz.Models
{
    public class UpdateProduktDto
    {
        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; }
        public int IloscObecna { get; set; }
        public int IloscZarezerwowana { get; set; }
        public int IloscDostepna { get; set; }
        [Required]
        public double Cena { get; set; }
        public virtual Lokalizacja Lokalizacja { get; set; }
        [Required]
        [MaxLength(13)]
        public string KodEan { get; set; }
        public string Kategoria { get; set; }

        public virtual List<DokumentProdukt> Dokumenty { get; set; }

        public virtual List<ProduktPrzyjecie> Przyjecia { get; set; }
    }
}
