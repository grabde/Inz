using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Inz.Entities;

namespace Inz.Models
{
    public class CreateDokumentDto
    {
        public int Id { get; set; }
        public TypDokumentu TypDokumentu { get; set; }
        [Required]
        [MaxLength(50)]
        public string NazwaKonrahenta { get; set; }
        [Required]
        public int Ilosc { get; set; }
        [Required]
        [MaxLength(13)]
        public string KodEan { get; set; }

        public virtual List<DokumentProdukt> Produkty { get; set; }
    }
}
