﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inz.Entities;

namespace Inz.Models
{
    public class DokumentDto
    {
        public int Id { get; set; }
        public TypDokumentu TypDokumentu { get; set; }
        public string NazwaKonrahenta { get; set; }
        public int Ilosc { get; set; }
        public string KodEan { get; set; }

        public virtual List<DokumentProdukt> Produkty { get; set; }
    }
}
