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
            this.CreateMap<Dokument, DokumentDto>()
                .ForMember(m => m.TypDokumentu, c => c.MapFrom(s => s.TypDokumentu.Id));

            this.CreateMap<CreateDokumentDto, Dokument>()
                .ForMember(r => r.TypDokumentu, c => c.MapFrom(dto => new TypDokumentu()
                {
                    Id = dto.TypDokumentu
                }));

            this.CreateMap<Przyjecie, PrzyjecieDto>();

            this.CreateMap<CreatePrzyjecieDto, Przyjecie>();

            this.CreateMap<Produkt, ProduktDto>();

            this.CreateMap<CreateProduktDto, Produkt>();
        }
    }
}
