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
    public class DokumentController : ControllerBase
    {
        private readonly IDokumentService _service;
        private readonly IProduktService _produkt;
        private readonly IConverter _converter;

        public DokumentController(IDokumentService dokumentService, IProduktService produktService, IConverter converter)
        {
            this._service = dokumentService;
            this._produkt = produktService;
            this._converter = converter;
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
        public ActionResult GetDokumentPdfById([FromRoute] int id)
        {
            //return this.File(_service.GetDokumentPdfById(id), "application/pdf");
            //return this.Ok(_service.GetDokumentPdfById(id));

            var dokument = this._service.GetDokumentById(id);
            var produkty = this._produkt.GetProdukty();

            string sciezka = @"C:\pdf\bartek.pdf";

            //przetworzyć string html na dokument PDF
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = $"Dokument {dokument.TypDokumentu.Nazwa}, id {dokument.Id}"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHtmlString(dokument, produkty),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "strona [page] z [toPage]", Line = true }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            byte[] file = this._converter.Convert(pdf);

            //wczytać ponownie plik

            //var stream = new FileStream(sciezka, FileMode.Open);

            //var result = new FileStreamResult(stream, "application/pdf");

            //return this.Ok(file);

            return this.File(file, "application/octet-stream");

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
