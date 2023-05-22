using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;
using Rotativa.AspNetCore;
using NuGet.Protocol.Plugins;


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
            ContenidoModel contenidoModel = new ContenidoModel();
            ReportesDatos reportesDatos = new ReportesDatos(connection);
            contenidoModel.perregistraMasc = reportesDatos.ReportesMascotasporFecha();
            return View(contenidoModel.perregistraMasc);
        }
        public ActionResult formUno() { 
            return View(); }
        public IActionResult GenerarPDF()
        {
            ContenidoModel contenidoModel = new ContenidoModel();
            ReportesDatos reportesDatos = new ReportesDatos(connection);
            contenidoModel.perregistraMasc = reportesDatos.ReportesMascotasporFecha();
            return new ViewAsPdf("formUno", contenidoModel.perregistraMasc)
            {
                FileName = "ReporteMascotas" + DateTime.Now.ToString("dd/MM/yyyy") + ".pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4


            };



        }


    }




}


