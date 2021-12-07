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
    public class KontrahentController : ControllerBase
    {
        private readonly IKontrahentService _service;

        public KontrahentController(IKontrahentService kontrahentService)
        {
            this._service = kontrahentService;
        }

        [HttpGet("kontrahenci")]
        public ActionResult<IEnumerable<KontrahentDto>> GetDokumenty()
        {
            return this.Ok(_service.GetKontrahenci());
        }

        [HttpGet("kontrahent/{id}")]
        public ActionResult<KontrahentDto> GetDokumentById([FromRoute] int id)
        {
            return this.Ok(_service.GetKontrahentById(id));
        }
    }
}
