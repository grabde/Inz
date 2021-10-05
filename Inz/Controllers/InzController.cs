using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inz.Entities;
using Microsoft.EntityFrameworkCore;
using Inz.Services;
using Inz.Models;
using AutoMapper;

namespace Inz.Controllers
{
    [Route("api/inz")]
    public class InzController : ControllerBase
    {
        private readonly ILogger<InzController> _logger;
        private readonly IInzService _service;
        private readonly InzDbContext _dbContext;
        private readonly IMapper _mapper;
         
        public InzController(ILogger<InzController> logger, IInzService inzService, InzDbContext inzDbContext, IMapper mapper)
        {
            this._logger = logger;
            this._service = inzService;
            this._dbContext = inzDbContext;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DokumentDto>> Get()
        {
            var dokumenty = _service.Get();
            var dokumentDtos = this._mapper.Map<List<DokumentDto>>(dokumenty);
            return this.Ok(dokumentDtos);
        }
    }
}
