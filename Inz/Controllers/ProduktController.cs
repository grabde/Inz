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
        private readonly IProduktService _service;

        public ProduktController(IProduktService ProduktService)
        {
            this._service = ProduktService;
        }

        [HttpGet("produkty")]
        public ActionResult<IEnumerable<ProduktDto>> GetPrzyjecia()
        {
            return this.Ok(_service.GetProdukty());
        }

        [HttpGet("produkt/{id}")]
        public ActionResult<ProduktDto> GetProduktById([FromRoute] int id)
        {
            return this.Ok(_service.GetProduktById(id));
        }

        [HttpPost("produkt")]
        public ActionResult CreateProdukt([FromBody] CreateProduktDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            ProduktDto Produkt = this._service.CreateProdukt(dto);
            return this.Created($"/api/Produkt/{Produkt.Id}", Produkt);
        }

        [HttpDelete("produkt/{id}")]
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

        [HttpPut("produkt/{id}")]
        public ActionResult<ProduktDto> Update([FromBody] UpdateProduktDto dto, [FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            ProduktDto produkt = this._service.Update(dto, id);

            if (produkt != null)
            {
                return this.Ok(produkt);
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}
