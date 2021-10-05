using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inz.Entities;
using Microsoft.AspNetCore.Mvc;
//using Inz.Models;
using Microsoft.EntityFrameworkCore;
//using AutoMapper;

namespace Inz.Services
{
    public interface IInzService
    {
        public IEnumerable<Dokument> Get();
    }
    public class InzService : IInzService
    {
        private readonly InzDbContext _dbContext;
        //private readonly IMapper _mapper;
        public InzService(InzDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Dokument> Get()
        {
            var dokumenty = this._dbContext
                .Dokument
                .Include(r => r.TypDokumentu)
                .Include(r => r.Produkty)
                .ToList();
            return dokumenty;
        }
    }
}
