using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inz.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inz.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Inz.Services
{
    public interface IDokumentService
    {
        public IEnumerable<DokumentDto> GetDokumenty();
        public DokumentDto GetDokumentById(int id);
        public DokumentDto CreateDokument(CreateDokumentDto dto);
        public bool Delete(int id);
        public DokumentDto Update(UpdateDokumentDto dto, int id);
    }
    public class DokumentService : IDokumentService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<DokumentService> _logger;

        public DokumentService(ILogger<DokumentService> logger, InzDbContext dbContext, IMapper mapper)
        {
            this._logger = logger;
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<DokumentDto> GetDokumenty()
        {
            var dokumenty = this._dbContext
                .Dokument
                .Include(r => r.TypDokumentu)
                .Include(r => r.Kontrahent)
                .Include(r => r.KtoWystawil)
                .Include(r => r.KtoZatwierdzilPrzyjal)
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
                .Include(r => r.Kontrahent)
                .Include(r => r.KtoWystawil)
                .Include(r => r.KtoZatwierdzilPrzyjal)
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

            TypDokumentu typDokumentu = null;
            if (dokument.TypDokumentu != null)
            {
                typDokumentu = this._dbContext
                    .TypDokumentu
                    .FirstOrDefault(r => r.Id == dokument.TypDokumentu.Id);
            }

            Kontrahent kontrahent = null;
            if (dokument.Kontrahent != null)
            {
                kontrahent = this._dbContext
                    .Kontrahent
                    .FirstOrDefault(r => r.Id == dokument.Kontrahent.Id);
            }

            Pracownik ktoWystawil = null;
            if (dokument.KtoWystawil != null)
            {
                ktoWystawil = this._dbContext
                    .Pracownik
                    .FirstOrDefault(r => r.Id == dokument.KtoWystawil.Id);
            }

            Pracownik ktoZatwierdzilPrzyjal = null;
            if (dokument.KtoZatwierdzilPrzyjal != null)
            {
                ktoZatwierdzilPrzyjal = this._dbContext
                    .Pracownik
                    .FirstOrDefault(r => r.Id == dokument.KtoZatwierdzilPrzyjal.Id);
            }

            dokument.TypDokumentu = null;
            dokument.Kontrahent = null;
            dokument.KtoWystawil = null;
            dokument.KtoZatwierdzilPrzyjal = null;
            this._dbContext.Dokument.Add(dokument);
            this._dbContext.SaveChanges();

            this._logger.LogWarning($"Dokument z id: {dokument.Id} CREATE wywołany");

            dokument = this._dbContext
                .Dokument
                .FirstOrDefault(r => r.Id == dokument.Id);

            dokument.TypDokumentu = typDokumentu;
            dokument.Kontrahent = kontrahent;
            dokument.KtoWystawil = ktoWystawil;
            dokument.KtoZatwierdzilPrzyjal = ktoZatwierdzilPrzyjal;

            this._dbContext.SaveChanges();

            var dokumentDto = this._mapper.Map<DokumentDto>(dokument);

            return dokumentDto;
        }

        public bool Delete(int id)
        {
            this._logger.LogWarning($"Dokument z id: {id} DELETE wywołany");

            var dokument = this._dbContext
                .Dokument
                .FirstOrDefault(r => r.Id == id);

            if (dokument is null)
            {
                return false;
            }

            this._dbContext.Dokument.Remove(dokument);
            this._dbContext.SaveChanges();
            return true;
        }

        public DokumentDto Update(UpdateDokumentDto dto, int id)
        {
            this._logger.LogWarning($"Dokument z id: {id} UPDATE wywołany");

            TypDokumentu typDokumentu = new TypDokumentu();
            if (dto.TypDokumentu != null)
            {
                typDokumentu = this._dbContext
                    .TypDokumentu
                    .FirstOrDefault(r => r.Id == dto.TypDokumentu.Id);
            }
            else
            {
                typDokumentu = this._dbContext
                    .TypDokumentu
                    .FirstOrDefault(r => r.Nazwa == null);
            }

            Kontrahent kontrahent = new Kontrahent();
            if (dto.Kontrahent != null)
            {
                kontrahent = this._dbContext
                    .Kontrahent
                    .FirstOrDefault(r => r.Id == dto.Kontrahent.Id);
            }
            else
            {
                kontrahent = this._dbContext
                    .Kontrahent
                    .FirstOrDefault(r => r.Nazwa == null);
            }

            Pracownik ktoWystawil = new Pracownik();
            if (dto.KtoWystawil != null)
            {
                ktoWystawil = this._dbContext
                    .Pracownik
                    .FirstOrDefault(r => r.Id == dto.KtoWystawil.Id);
            }
            else
            {
                ktoWystawil = this._dbContext
                    .Pracownik
                    .FirstOrDefault(r => r.Imie == null);
            }

            Pracownik ktoZatwierdzilPrzyjal = new Pracownik();
            if (dto.KtoZatwierdzilPrzyjal != null)
            {
                ktoZatwierdzilPrzyjal = this._dbContext
                    .Pracownik
                    .FirstOrDefault(r => r.Id == dto.KtoZatwierdzilPrzyjal.Id);
            }
            else
            {
                ktoZatwierdzilPrzyjal = this._dbContext
                    .Pracownik
                    .FirstOrDefault(r => r.Imie == null);
            }

            this._dbContext.SaveChanges();

            var dokument = this._dbContext
                .Dokument
                .FirstOrDefault(r => r.Id == id);

            if (dokument is null)
            {
                return null;
            }

            dokument.TypDokumentu = typDokumentu;
            dokument.Kontrahent = kontrahent;
            dokument.KtoWystawil = ktoWystawil;
            dokument.KtoZatwierdzilPrzyjal = ktoZatwierdzilPrzyjal;
            dokument.DataWystawienia = dto.DataWystawienia;
            dokument.DataZatwierdzeniaPrzyjecia = dto.DataZatwierdzeniaPrzyjecia;

            this._dbContext.SaveChanges();

            var produkty = this._dbContext
                .DokumentProdukt
                .Where(r => r.DokumentId == id)
                .ToList();

            if (dto.Produkty != null)
            {
                foreach (var item in dto.Produkty)
                {
                    item.DokumentId = id;
                }

                var doUsuniecia = produkty.Except(dto.Produkty);
                var doWstawienia = dto.Produkty.Except(produkty);

                this._dbContext.RemoveRange(doUsuniecia);
                this._dbContext.AddRange(doWstawienia);
            }
            else
            {
                this._dbContext.RemoveRange(produkty);
            }

            this._dbContext.SaveChanges();

            return this.GetDokumentById(id);
        }
    }
}
