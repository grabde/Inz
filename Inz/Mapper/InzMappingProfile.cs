using AutoMapper;
using Inz.Entities;
using Inz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inz.Mapper
{
    public class InzMappingProfile : Profile
    {
        public InzMappingProfile()
        {
            this.CreateMap<Dokument, DokumentDto>()
                .ForMember(m => m.TypDokumentu, c => c.MapFrom(s => s.TypDokumentu.Id));
        }
    }
}
