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
    public interface IProduktService
    {
        public IEnumerable<ProduktDto> GetProdukty();
        public ProduktDto GetProduktById(int id);
        public ProduktDto CreateProdukt(CreateProduktDto dto);
        public bool Delete(int id);
        public ProduktDto Update(UpdateProduktDto dto, int id);
    }
    public class ProduktService : IProduktService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProduktService> _logger;

        public ProduktService(ILogger<ProduktService> logger, InzDbContext dbContext, IMapper mapper)
        {
            this._logger = logger;
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<ProduktDto> GetProdukty()
        {
            var produkt = this._dbContext
                .Produkt
                .Include(r => r.Dokumenty)
                .Include(r => r.Przyjecia)
                .Include(r => r.Lokalizacja)
                .ToList();

            var produktDto = this._mapper.Map<List<ProduktDto>>(produkt);
            return produktDto;
        }
        
        public ProduktDto GetProduktById(int id)
        {
            var produkt = this._dbContext
                .Produkt
                .Include(r => r.Dokumenty)
                .Include(r => r.Przyjecia)
                .Include(r => r.Lokalizacja)
                .FirstOrDefault(r => r.Id == id);

            if (produkt is null)
            {
                return null;
            }

            var produktDto = this._mapper.Map<ProduktDto>(produkt);
            return produktDto;
        }

        public ProduktDto CreateProdukt(CreateProduktDto dto)
        {
            var produkt = this._mapper.Map<Produkt>(dto);

            Lokalizacja lokalizacja = null;
            if (produkt.Lokalizacja != null)
            {
                lokalizacja = this._dbContext
                    .Lokalizacja
                    .FirstOrDefault(r => r.Id == produkt.Lokalizacja.Id);
            }

            produkt.Lokalizacja = null;
            this._dbContext.Produkt.Add(produkt);
            this._dbContext.SaveChanges();

            produkt = this._dbContext
                .Produkt
                .FirstOrDefault(r => r.Id == produkt.Id);

            produkt.Lokalizacja = lokalizacja;
            this._dbContext.SaveChanges();

            var produktDto = this._mapper.Map<ProduktDto>(produkt);

            this._logger.LogWarning($"Produkt z id: {produkt.Id} CREATE wywołany");

            return produktDto;
        }

        public bool Delete(int id)
        {
            this._logger.LogWarning($"Produkt z id: {id} DELETE wywołany");

            var produkt = this._dbContext
                .Produkt
                .FirstOrDefault(r => r.Id == id);

            if (produkt is null)
            {
                return false;
            }

            this._dbContext.Produkt.Remove(produkt);
            this._dbContext.SaveChanges();
            return true;
        }

        public ProduktDto Update(UpdateProduktDto dto, int id)
        {
            this._logger.LogWarning($"Produkt z id: {id} UPDATE wywołany");

            Lokalizacja lokalizacja = new Lokalizacja();
            if (dto.Lokalizacja != null)
            {
                lokalizacja = this._dbContext
                    .Lokalizacja
                    .FirstOrDefault(r => r.Id == dto.Lokalizacja.Id);
                this._dbContext.SaveChanges();
            }
            else
            {
                lokalizacja = this._dbContext
                    .Lokalizacja
                    .FirstOrDefault(r => r.NumerRegalu == 0);
                this._dbContext.SaveChanges();
            }

            var produkt = this._dbContext
                .Produkt
                .FirstOrDefault(r => r.Id == id);

            if (produkt is null)
            {
                return null;
            }

            produkt.Nazwa = dto.Nazwa;
            produkt.IloscObecna = dto.IloscObecna;
            produkt.IloscZarezerwowana = dto.IloscZarezerwowana;
            produkt.IloscDostepna = dto.IloscDostepna;
            produkt.Cena = dto.Cena;
            produkt.Lokalizacja = lokalizacja;
            produkt.KodEan = dto.KodEan;
            produkt.Kategoria = dto.Kategoria;
            this._dbContext.SaveChanges();

            var dokumenty = this._dbContext
                .DokumentProdukt
                .Where(r => r.ProduktId == id)
                .ToList();

            if (dto.Dokumenty != null)
            {
                foreach (var item in dto.Dokumenty)
                {
                    item.ProduktId = id;
                }

                var doUsuniecia = dokumenty.Except(dto.Dokumenty);
                var doWstawienia = dto.Dokumenty.Except(dokumenty);

                this._dbContext.RemoveRange(doUsuniecia);
                this._dbContext.AddRange(doWstawienia);
            }
            else
            {
                this._dbContext.RemoveRange(dokumenty);
            }

            this._dbContext.SaveChanges();

            var przyjecia = this._dbContext
                .ProduktPrzyjecie
                .Where(r => r.ProduktId == id)
                .ToList();

            if (dto.Przyjecia != null)
            {
                foreach (var item in dto.Przyjecia)
                {
                    item.ProduktId = id;
                }

                var doUsuniecia = przyjecia.Except(dto.Przyjecia);
                var doWstawienia = dto.Przyjecia.Except(przyjecia);

                this._dbContext.RemoveRange(doUsuniecia);
                this._dbContext.AddRange(doWstawienia);
            }
            else
            {
                this._dbContext.RemoveRange(dokumenty);
            }

            this._dbContext.SaveChanges();

            return this.GetProduktById(id);
        }
    }
}
