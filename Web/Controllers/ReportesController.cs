using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;


namespace Web.Controllers
{
    public class ReportesController : Controller
    {
        private readonly MySqlConnection connection;

        public ReportesController(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public ActionResult InicioReportes()
        {
            List<ContenidoModel> contenidoModel = new List<ContenidoModel>();
            ReportesDatos reportesDatos = new ReportesDatos(connection);
            PerRegistraMascModel perRegistraMascModel = new PerRegistraMascModel();
            MascotaModel mascotaModel = new MascotaModel();
            contenidoModel = reportesDatos.ReportesMascotasporFecha(perRegistraMascModel, mascotaModel);
            return View(contenidoModel);
        }

        [HttpPost]
        public ActionResult GenerarPDF(string html)
        {
            // Ruta de salida del archivo PDF
            string outputDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\ArchivosPDF");
            string outputFilePath = Path.Combine(outputDirectory, "reportes.pdf");

            // Crear un documento PDF
            Document document = new Document();

            try
            {
                // Inicializar el escritor PDF
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputFilePath, FileMode.Create));

                // Abrir el documento
                document.Open();

                // Convertir el contenido HTML a PDF
                using (var htmlStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlStream, null, System.Text.Encoding.UTF8, FontFactory.FontImp);
                }
            }
            finally
            {
                // Cerrar el documento
                document.Close();
            }

            // Devolver el archivo PDF generado
            return File(outputFilePath, "application/pdf", "formulario.pdf");
        }





    }
}
