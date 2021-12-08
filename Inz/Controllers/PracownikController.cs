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
    public class PracownikController : ControllerBase
    {
        private readonly IPracownikService _service;

        public PracownikController(IPracownikService pracownikService)
        {
            this._service = pracownikService;
        }

        [HttpGet("pracownicy")]
        public ActionResult<IEnumerable<PracownikDto>> GetPracownicy()
        {
            return this.Ok(_service.GetPracownicy());
        }

        [HttpGet("pracownik/{id}")]
        public ActionResult<PracownikDto> GetPracowniktById([FromRoute] int id)
        {
            return this.Ok(_service.GetPracownikById(id));
        }
    }
}
