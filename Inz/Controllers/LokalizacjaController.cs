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
using DinkToPdf;
using Inz.Utility;
using System.IO;
using DinkToPdf.Contracts;

namespace Inz.Controllers
{
    [Route("api/inz/")]
    public class LokalizacjaController : ControllerBase
    {
        private readonly ILokalizacjaService _service;

        public LokalizacjaController(ILokalizacjaService lokalizacjaService)
        {
            this._service = lokalizacjaService;
        }

        [HttpGet("lokalizacje")]
        public ActionResult<IEnumerable<LokalizacjaDto>> GetLokalizacje()
        {
            return this.Ok(_service.GetLokalizacje());
        }

        [HttpGet("lokalizacja/{id}")]
        public ActionResult<LokalizacjaDto> GetLokalizacjatById([FromRoute] int id)
        {
            return this.Ok(_service.GetLokalizacjaById(id));
        }
    }
}
