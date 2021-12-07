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
    public interface ITypDokumentuService
    {
        public IEnumerable<TypDokumentuDto> GetTypyDokumentow();
        public TypDokumentuDto GetTypDokumentuById(int id);
    }
    public class TypDokumentuService : ITypDokumentuService
    {
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<TypDokumentuService> _logger;

        public TypDokumentuService(ILogger<TypDokumentuService> logger, InzDbContext dbContext, IMapper mapper)
        {
            this._logger = logger;
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        
        public IEnumerable<TypDokumentuDto> GetTypyDokumentow()
        {
            var typyDokumentow = this._dbContext
                .TypDokumentu
                .ToList();

            var typyDokumentowDto = this._mapper.Map<List<TypDokumentuDto>>(typyDokumentow);
            return typyDokumentowDto;
        }
        
        public TypDokumentuDto GetTypDokumentuById(int id)
        {
            var typDokumentu = this._dbContext
                .TypDokumentu
                .FirstOrDefault(r => r.Id == id);

            if (typDokumentu is null)
            {
                return null;
            }

            var typDokumentuDto = this._mapper.Map<TypDokumentuDto>(typDokumentu);
            return typDokumentuDto;
        }
    }
}
