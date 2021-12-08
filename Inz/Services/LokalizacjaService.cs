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
using Inz.Utility;
using DinkToPdf.Contracts;
using DinkToPdf;
using System.IO;

namespace Inz.Services
{
    public interface ILokalizacjaService
    {
        public IEnumerable<LokalizacjaDto> GetLokalizacje();
        public LokalizacjaDto GetLokalizacjaById(int id);
    }
    public class LokalizacjaService : ILokalizacjaService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<LokalizacjaService> _logger;

        public LokalizacjaService(ILogger<LokalizacjaService> logger, InzDbContext dbContext, IMapper mapper)
        {
            this._logger = logger;
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<LokalizacjaDto> GetLokalizacje()
        {
            var lokalizacje = this._dbContext
                .Lokalizacja
                .ToList();

            var lokalizacjeDto = this._mapper.Map<List<LokalizacjaDto>>(lokalizacje);
            return lokalizacjeDto;
        }
        
        public LokalizacjaDto GetLokalizacjaById(int id)
        {
            var lokalizacja = this._dbContext
                .Lokalizacja
                .FirstOrDefault(r => r.Id == id);

            if (lokalizacja is null)
            {
                return null;
            }

            var lokalizacjaDto = this._mapper.Map<LokalizacjaDto>(lokalizacja);
            return lokalizacjaDto;
        }
    }
}
