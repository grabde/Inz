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
    public class PrzyjecieController : ControllerBase
    {
        private readonly ILogger<PrzyjecieController> _logger;
        private readonly IPrzyjecieService _service;

        public PrzyjecieController(ILogger<PrzyjecieController> logger, IPrzyjecieService przyjecieService)
        {
            this._logger = logger;
            this._service = przyjecieService;
        }

        [HttpGet("przyjecia")]
        public ActionResult<IEnumerable<PrzyjecieDto>> GetPrzyjecia()
        {
            return this.Ok(_service.GetPrzyjecie());
        }

        [HttpGet("przyjecie/{id}")]
        public ActionResult<IEnumerable<PrzyjecieDto>> GetPrzyjecieById([FromRoute] int id)
        {
            return this.Ok(_service.GetPrzyjecieById(id));
        }

        [HttpPost("przyjecie")]
        public ActionResult CreatePrzyjecie([FromBody] CreatePrzyjecieDto dto)
        {
            PrzyjecieDto przyjecie = this._service.CreatePrzyjecie(dto);
            return this.Created($"/api/przyjecie/{przyjecie.Id}", przyjecie);
        }
    }
}
