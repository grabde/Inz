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
        private readonly IPrzyjecieService _service;

        public PrzyjecieController(IPrzyjecieService przyjecieService)
        {
            this._service = przyjecieService;
        }

        [HttpGet("przyjecia")]
        public ActionResult<IEnumerable<PrzyjecieDto>> GetPrzyjecia()
        {
            return this.Ok(_service.GetPrzyjecia());
        }

        [HttpGet("przyjecie/{id}")]
        public ActionResult<PrzyjecieDto> GetPrzyjecieById([FromRoute] int id)
        {
            return this.Ok(_service.GetPrzyjecieById(id));
        }

        [HttpPost("przyjecie")]
        public ActionResult CreatePrzyjecie([FromBody] CreatePrzyjecieDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            PrzyjecieDto przyjecie = this._service.CreatePrzyjecie(dto);
            return this.Created($"/api/przyjecie/{przyjecie.Id}", przyjecie);
        }

        [HttpDelete("przyjecie/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            bool isDeleted = this._service.Delete(id);

            if (isDeleted)
            {
                return this.NoContent();
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpPut("przyjecie/{id}")]
        public ActionResult<PrzyjecieDto> Update([FromBody] UpdatePrzyjecieDto dto, [FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            PrzyjecieDto przyjecie = this._service.Update(dto, id);

            if (przyjecie != null)
            {
                return this.Ok(przyjecie);
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}
