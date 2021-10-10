using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inz.Entities;
using Inz.Models;

namespace Inz.Mapper
{
    public class InzMappingProfile : Profile
    {
        public InzMappingProfile()
        {
            this.CreateMap<Dokument, DokumentDto>();

            this.CreateMap<Przyjecie, PrzyjecieDto>();

            this.CreateMap<Produkt, ProduktDto>();

            this.CreateMap<CreateDokumentDto, Dokument>();

            this.CreateMap<CreatePrzyjecieDto, Przyjecie>();

            this.CreateMap<CreateProduktDto, Produkt>();

            this.CreateMap<UpdateDokumentDto, Dokument>();

            this.CreateMap<UpdatePrzyjecieDto, Przyjecie>();

            this.CreateMap<UpdateProduktDto, Produkt>();
        }
    }
}
