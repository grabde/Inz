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
    public interface IKontrahentService
    {
        public IEnumerable<KontrahentDto> GetKontrahenci();
        public KontrahentDto GetKontrahentById(int id);
    }
    public class KontrahentService : IKontrahentService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<KontrahentService> _logger;

        public KontrahentService(ILogger<KontrahentService> logger, InzDbContext dbContext, IMapper mapper)
        {
            this._logger = logger;
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<KontrahentDto> GetKontrahenci()
        {
            var kontrahenci = this._dbContext
                .Kontrahent
                .ToList();

            var kontrahenciDto = this._mapper.Map<List<KontrahentDto>>(kontrahenci);
            return kontrahenciDto;
        }
        
        public KontrahentDto GetKontrahentById(int id)
        {
            var kontrahent = this._dbContext
                .Kontrahent
                .FirstOrDefault(r => r.Id == id);

            if (kontrahent is null)
            {
                return null;
            }

            var kontrahentDto = this._mapper.Map<KontrahentDto>(kontrahent);
            return kontrahentDto;
        }
    }
}
