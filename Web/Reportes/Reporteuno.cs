using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

public class Reporteuno
{
    public MemoryStream GenerarPDFDesdeHTML(string html)
    {
        using (MemoryStream memoryStream = new MemoryStream())

        {
            // Crear el documento PDF
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            // Convertir el HTML en PDF
            using (var htmlStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
            {
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlStream, null, System.Text.Encoding.UTF8, FontFactory.FontImp);
            }

            // Cerrar el documento PDF
            document.Close();

            memoryStream.Position = 0;
            return memoryStream;
        }
    }
}
