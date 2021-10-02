using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inz.Entities
{
    public class Przyjecie
    {
        public int Id { get; set; }
        public int ProduktId { get; set; }
        public DateTime DataPrzyjazdu { get; set; }
        public DateTime DataWypakowania { get; set; }
        public string KtoWystawil { get; set; }
        public string KtoObsluguje { get; set; }

        public virtual List<Produkt> Produkty { get; set; }
    }
}
