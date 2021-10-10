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
    public interface IPrzyjecieService
    {
        public IEnumerable<PrzyjecieDto> GetPrzyjecia();
        public PrzyjecieDto GetPrzyjecieById(int id);
        public PrzyjecieDto CreatePrzyjecie(CreatePrzyjecieDto dto);
        public bool Delete(int id);
        public PrzyjecieDto Update(UpdatePrzyjecieDto dto, int id);
    }
    public class PrzyjecieService : IPrzyjecieService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<PrzyjecieService> _logger;

        public PrzyjecieService(ILogger<PrzyjecieService> logger, InzDbContext dbContext, IMapper mapper)
        {
            this._logger = logger;
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<PrzyjecieDto> GetPrzyjecia()
        {
            var przyjecia = this._dbContext
                .Przyjecie
                .Include(r => r.Produkty)
                .ToList();

            var przyjeciaDto = this._mapper.Map<List<PrzyjecieDto>>(przyjecia);
            return przyjeciaDto;
        }
        
        public PrzyjecieDto GetPrzyjecieById(int id)
        {
            var przyjecie = this._dbContext
                .Przyjecie
                .Include(r => r.Produkty)
                .FirstOrDefault(r => r.Id == id);

            if (przyjecie is null)
            {
                return null;
            }

            var przyjecieDto = this._mapper.Map<PrzyjecieDto>(przyjecie);
            return przyjecieDto;
        }

        public PrzyjecieDto CreatePrzyjecie(CreatePrzyjecieDto dto)
        {
            var przyjecie = this._mapper.Map<Przyjecie>(dto);

            this._dbContext.Przyjecie.Add(przyjecie);
            this._dbContext.SaveChanges();

            var przyjecieDto = this._mapper.Map<PrzyjecieDto>(przyjecie);

            this._logger.LogWarning($"Przyjecie z id: {przyjecie.Id} CREATE wywołany");

            return przyjecieDto;
        }

        public bool Delete(int id)
        {
            this._logger.LogWarning($"Przyjecie z id: {id} DELETE wywołany");

            var przyjecie = this._dbContext
                .Przyjecie
                .FirstOrDefault(r => r.Id == id);

            if (przyjecie is null)
            {
                return false;
            }

            this._dbContext.Przyjecie.Remove(przyjecie);
            this._dbContext.SaveChanges();
            return true;
        }

        public PrzyjecieDto Update(UpdatePrzyjecieDto dto, int id)
        {
            this._logger.LogWarning($"Przyjecie z id: {id} UPDATE wywołany");

            var przyjecie = this._dbContext
                .Przyjecie
                .FirstOrDefault(r => r.Id == id);

            if (przyjecie is null)
            {
                return null;
            }

            przyjecie.DataPrzyjazdu = dto.DataPrzyjazdu;
            przyjecie.DataWypakowania = dto.DataWypakowania;
            przyjecie.KtoWystawil = dto.KtoWystawil;
            przyjecie.KtoObsluguje = dto.KtoObsluguje;
            this._dbContext.SaveChanges();

            var produkty = this._dbContext
                .ProduktPrzyjecie
                .Where(r => r.PrzyjecieId == id)
                .ToList();

            if (dto.Produkty != null)
            {
                foreach (var item in dto.Produkty)
                {
                    item.PrzyjecieId = id;
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

            return this.GetPrzyjecieById(id);
        }
    }
}
