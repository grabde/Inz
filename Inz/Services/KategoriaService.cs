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
    public interface IKategoriaService
    {
        public IEnumerable<KategoriaDto> GetKategorie();
        public KategoriaDto GetKategoriaById(int id);
    }
    public class KategoriaService : IKategoriaService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<KategoriaService> _logger;

        public KategoriaService(ILogger<KategoriaService> logger, InzDbContext dbContext, IMapper mapper)
        {
            this._logger = logger;
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<KategoriaDto> GetKategorie()
        {
            var kategorie = this._dbContext
                .Kategoria
                .ToList();

            var kategorieDto = this._mapper.Map<List<KategoriaDto>>(kategorie);
            return kategorieDto;
        }
        
        public KategoriaDto GetKategoriaById(int id)
        {
            var kategoria = this._dbContext
                .Kategoria
                .FirstOrDefault(r => r.Id == id);

            if (kategoria is null)
            {
                return null;
            }

            var kategoriaDto = this._mapper.Map<KategoriaDto>(kategoria);
            return kategoriaDto;
        }
    }
}
