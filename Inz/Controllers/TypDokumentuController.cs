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
    public class TypDokumentuController : ControllerBase
    {
        private readonly ITypDokumentuService _service;

        public TypDokumentuController(ITypDokumentuService typDokumentuService)
        {
            this._service = typDokumentuService;
        }

        [HttpGet("typy_dokumentow")]
        public ActionResult<IEnumerable<TypDokumentuDto>> GetTypyDokumentow()
        {
            return this.Ok(_service.GetTypyDokumentow());
        }

        [HttpGet("typ_dokumentu/{id}")]
        public ActionResult<TypDokumentuDto> GetTypDokumentutById([FromRoute] int id)
        {
            return this.Ok(_service.GetTypDokumentuById(id));
        }
    }
}
