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
    public interface IPrzyjecieService
    {
        public IEnumerable<PrzyjecieDto> GetPrzyjecie();
        public PrzyjecieDto GetPrzyjecieById(int id);
        public PrzyjecieDto CreatePrzyjecie(CreatePrzyjecieDto dto);
    }
    public class PrzyjecieService : IPrzyjecieService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;

        public PrzyjecieService(InzDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<PrzyjecieDto> GetPrzyjecie()
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
            return przyjecieDto;
        }
    }
}
