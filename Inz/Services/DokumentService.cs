using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inz.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inz.Models;
using AutoMapper;

namespace Inz.Services
{
    public interface IDokumentService
    {
        public IEnumerable<DokumentDto> Get();
        public DokumentDto GetDokumentById(int id);
        public DokumentDto CreateDokument(CreateDokumentDto dto);
    }
    public class DokumentService : IDokumentService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;

        public DokumentService(InzDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<DokumentDto> Get()
        {
            var dokumenty = this._dbContext
                .Dokument
                .Include(r => r.TypDokumentu)
                .Include(r => r.Produkty)
                .ToList();

            var dokumentyDto = this._mapper.Map<List<DokumentDto>>(dokumenty);
            return dokumentyDto;
        }
        
        public DokumentDto GetDokumentById(int id)
        {
            var dokument = this._dbContext
                .Dokument
                .Include(r => r.TypDokumentu)
                .Include(r => r.Produkty)
                .FirstOrDefault(r => r.Id == id);

            if (dokument is null)
            {
                return null;
            }

            var dokumentDto = this._mapper.Map<DokumentDto>(dokument);
            return dokumentDto;
        }

        public DokumentDto CreateDokument(CreateDokumentDto dto)
        {
            var dokument = this._mapper.Map<Dokument>(dto);

            TypDokumentu typDokumentu = this._dbContext
                .TypDokumentu
                .FirstOrDefault(r => r.Id == dokument.TypDokumentu.Id);

            dokument.TypDokumentu = null;
            this._dbContext.Dokument.Add(dokument);
            this._dbContext.SaveChanges();

            dokument = this._dbContext
                .Dokument
                .FirstOrDefault(r => r.Id == dokument.Id);

            dokument.TypDokumentu = typDokumentu;
            this._dbContext.SaveChanges();

            var dokumentDto = this._mapper.Map<DokumentDto>(dokument);

            return dokumentDto;
        }
    }
}
