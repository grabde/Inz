using Inz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHtmlString(DokumentDto dokument, IEnumerable<ProduktDto> produkty)
        {
            var sb = new StringBuilder();

             sb.Append(@"
                        <!DOCTYPE HTML>
                        <html>
                            <head>
                                
                            </head>
                            <body>
                                <h1>Dokument# " + dokument.Id + "</h1>" +
                                "<div class='all'>" +
                                "<div class='Lee'>" +
                                    "<div class='top-left'> Dokument: " + dokument.TypDokumentu.Nazwa + "</div>" +
                                    "<div class='top-mid'>Wystawił(a): " + dokument.KtoWystawil.Imie + " " + dokument.KtoWystawil.Nazwisko + "</div>" +
                                    "<div class='top-mid'>Kontrachent: " + dokument.Kontrahent.Nazwa + " </div>" +
                                " </div>" +
                                "<div class='top-right'>Data wystawienia: " + dokument.DataWystawienia +
                                "</div>"
            );

            sb.Append(@"     <div> <table align='center'>
                                    <tr>
                                        <th>Indeks</th>
                                        <th>Nazwa materiału</th>
                                        <th>Kategoria</th>
                                        <th>Ilość</th>
                                        <th>Bieżąca ilość</th>
                                    </tr>
                                        </div>");

            foreach (var produkt in dokument.Produkty)
            {
                string nazwa = "";
                string kategoria = "";
                int obecna = 0;

                try
                {
                    nazwa = produkty.FirstOrDefault(x => x.Id == produkt.ProduktId).Nazwa;
                }
                catch (Exception e)
                {
                }

                try
                {
                    kategoria = produkty.FirstOrDefault(x => x.Id == produkt.ProduktId).Kategoria.Nazwa;
                }
                catch (Exception e)
                {
                }

                try
                {
                    obecna = produkty.FirstOrDefault(x => x.Id == produkt.ProduktId).IloscObecna;
                }
                catch (Exception e)
                {
                }

                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                  </tr>", produkt.ProduktId, nazwa, kategoria, produkt.Ilosc, obecna);
            }

            sb.Append(@" <div>
                            <div class='bottom'>
                                <div class='bottom-mid'>Zatwierdził(a): " + dokument.KtoZatwierdzilPrzyjal.Imie + " " + dokument.KtoWystawil.Nazwisko + "</div>" +
                                "<div class='bottom-date'>Data zatwierdzenia: " + dokument.DataZatwierdzeniaPrzyjecia + "</div>" +
                                "<div class='bottom-podpis'>Podpis/Pieczątka: </div>" +
                                "<div class='bottom-mid2'></div>" +
                                "<div class='bottom-box'></div>" +

                            "</div>" +
                         "</div>"
                        );


            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();

        }
    }
}
