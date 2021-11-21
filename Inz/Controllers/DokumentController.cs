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
        private readonly IDokumentService _service;

        public DokumentController(IDokumentService dokumentService)
        {
            this._service = dokumentService;
        }

        [HttpGet("dokumenty")]
        public ActionResult<IEnumerable<DokumentDto>> GetDokumenty()
        {
            return this.Ok(_service.GetDokumenty());
        }

        [HttpGet("dokument/{id}")]
        public ActionResult<DokumentDto> GetDokumentById([FromRoute] int id)
        {
            return this.Ok(_service.GetDokumentById(id));
        }

        [HttpGet("dokument/pdf/{id}")]
        public ActionResult<DokumentDto> GetDokumentPdfById([FromRoute] int id)
        {   
            //kiedy chcemy wyświetlić pdf w przeglądarce
            return this.File(_service.GetDokumentPdfById(id), "application/pdf");
            
            //kiedy chcemy zewrócić tablice bajtów
            //return this.Ok(_service.GetDokumentPdfById(id));
        }

        [HttpPost("dokument")]
        public ActionResult CreateDokument([FromBody] CreateDokumentDto dto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            DokumentDto dokument = this._service.CreateDokument(dto);
            return this.Created($"/api/dokument/{dokument.Id}", dokument);
        }

        [HttpDelete("dokument/{id}")]
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

        [HttpPut("dokument/{id}")]
        public ActionResult<DokumentDto> Update([FromBody] UpdateDokumentDto dto, [FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            DokumentDto dokument = this._service.Update(dto, id);

            if (dokument != null)
            {
                return this.Ok(dokument);
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}
