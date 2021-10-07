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
    public interface IProduktService
    {
        public IEnumerable<ProduktDto> GetProdukt();
        public ProduktDto GetProduktById(int id);
        public ProduktDto CreateProdukt(CreateProduktDto dto);
    }
    public class ProduktService : IProduktService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProduktService(InzDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<ProduktDto> GetProdukt()
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

            Lokalizacja lokalizacja = this._dbContext
                .Lokalizacja
                .FirstOrDefault(r => r.Id == produkt.Lokalizacja.Id);

            produkt.Lokalizacja = null;

            this._dbContext.Produkt.Add(produkt);
            this._dbContext.SaveChanges();

            produkt = this._dbContext
                .Produkt
                .FirstOrDefault(r => r.Id == produkt.Id);

            produkt.Lokalizacja = lokalizacja;
            this._dbContext.SaveChanges();

            var produktDto = this._mapper.Map<ProduktDto>(produkt);
            return produktDto;
        }
    }
}
