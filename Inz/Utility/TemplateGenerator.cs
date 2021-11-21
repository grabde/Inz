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
        public static string GetHtmlString(DokumentDto dto)
        {
            var sb = new StringBuilder();

            sb.Append(@"
                <html>
                    <head></head>
                    <body>
            ");

            sb.AppendFormat(@"
                <div class='header'>
                    <h1>
                        Id dokumentu: {0}
                     </h1>
                    <h1>
                        Typ dokumentu: {1}
                     </h1>
                </div>
            ", dto.Id, dto.TypDokumentu.Nazwa);

            sb.Append(@"
                    </body>
                </html>
            ");

            return sb.ToString();
        }
    }
}
