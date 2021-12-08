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
    public class KategoriaController : ControllerBase
    {
        private readonly IKategoriaService _service;

        public KategoriaController(IKategoriaService kategoriaService)
        {
            this._service = kategoriaService;
        }

        [HttpGet("kategorie")]
        public ActionResult<IEnumerable<KategoriaDto>> GetKategorie()
        {
            return this.Ok(_service.GetKategorie());
        }

        [HttpGet("kategoria/{id}")]
        public ActionResult<KategoriaDto> GetKategoriatById([FromRoute] int id)
        {
            return this.Ok(_service.GetKategoriaById(id));
        }
    }
}
