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

            this.CreateMap<Produkt, ProduktDto>();

            this.CreateMap<Kontrahent, KontrahentDto>();

            this.CreateMap<TypDokumentu, TypDokumentuDto>();

            this.CreateMap<Pracownik, PracownikDto>();

            this.CreateMap<Kategoria, KategoriaDto>();

            this.CreateMap<Lokalizacja, LokalizacjaDto>();

            this.CreateMap<CreateDokumentDto, Dokument>();

            this.CreateMap<CreateProduktDto, Produkt>();

            this.CreateMap<UpdateDokumentDto, Dokument>();

            this.CreateMap<UpdateProduktDto, Produkt>();
        }
    }
}
