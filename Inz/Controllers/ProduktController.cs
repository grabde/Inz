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
    [Route("api/inz/")]
    public class ProduktController : ControllerBase
    {
        private readonly ILogger<ProduktController> _logger;
        private readonly IProduktService _service;

        public ProduktController(ILogger<ProduktController> logger, IProduktService ProduktService)
        {
            this._logger = logger;
            this._service = ProduktService;
        }

        [HttpGet("produkty")]
        public ActionResult<IEnumerable<ProduktDto>> GetPrzyjecia()
        {
            return this.Ok(_service.GetProdukt());
        }

        [HttpGet("produkt/{id}")]
        public ActionResult<IEnumerable<ProduktDto>> GetProduktById([FromRoute] int id)
        {
            return this.Ok(_service.GetProduktById(id));
        }

        [HttpPost("produkt")]
        public ActionResult CreateProdukt([FromBody] CreateProduktDto dto)
        {
            ProduktDto Produkt = this._service.CreateProdukt(dto);
            return this.Created($"/api/Produkt/{Produkt.Id}", Produkt);
        }
    }
}
