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
    public class DokumentController : ControllerBase
    {
        private readonly ILogger<DokumentController> _logger;
        private readonly IDokumentService _service;

        public DokumentController(ILogger<DokumentController> logger, IDokumentService dokumentService)
        {
            this._logger = logger;
            this._service = dokumentService;
        }

        [HttpGet("dokumenty")]
        public ActionResult<IEnumerable<DokumentDto>> GetDokumenty()
        {
            return this.Ok(_service.Get());
        }

        [HttpGet("dokument/{id}")]
        public ActionResult<IEnumerable<DokumentDto>> GetDokumentById([FromRoute] int id)
        {
            return this.Ok(_service.GetDokumentById(id));
        }

        [HttpPost("dokument")]
        public ActionResult CreateDokument([FromBody] CreateDokumentDto dto)
        {
            DokumentDto dokument = this._service.CreateDokument(dto);
            return this.Created($"/api/dokument/{dokument.Id}", dokument);
        }
    }
}
