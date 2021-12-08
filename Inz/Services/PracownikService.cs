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
    public interface IPracownikService
    {
        public IEnumerable<PracownikDto> GetPracownicy();
        public PracownikDto GetPracownikById(int id);
    }
    public class PracownikService : IPracownikService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<PracownikService> _logger;

        public PracownikService(ILogger<PracownikService> logger, InzDbContext dbContext, IMapper mapper)
        {
            this._logger = logger;
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<PracownikDto> GetPracownicy()
        {
            var pracownicy = this._dbContext
                .Pracownik
                .ToList();

            var pracownicyDto = this._mapper.Map<List<PracownikDto>>(pracownicy);
            return pracownicyDto;
        }
        
        public PracownikDto GetPracownikById(int id)
        {
            var Pracownik = this._dbContext
                .Pracownik
                .FirstOrDefault(r => r.Id == id);

            if (Pracownik is null)
            {
                return null;
            }

            var PracownikDto = this._mapper.Map<PracownikDto>(Pracownik);
            return PracownikDto;
        }
    }
}
