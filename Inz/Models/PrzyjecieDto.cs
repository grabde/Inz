using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inz.Entities;

namespace Inz.Models
{
    public class PrzyjecieDto
    {
        public int Id { get; set; }
        public DateTime DataPrzyjazdu { get; set; }
        public DateTime DataWypakowania { get; set; }
        public string KtoWystawil { get; set; }
        public string KtoObsluguje { get; set; }

        public virtual List<ProduktPrzyjecie> Produkty { get; set; }
    }
}
