using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class MotivoReportesController : Controller
    {
        private readonly MySqlConnection connection;

        public MotivoReportesController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaMotivo()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarMotivoReporte());
        }

        public ActionResult createMotvo(int idMotivo, string nombreMotivo)
        {
            MotivoReporteModel motivo = new MotivoReporteModel();
            motivo.MOT_ID = idMotivo;
            motivo.MOT_MotivoReporte = nombreMotivo;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.insertarMotivo(motivo);
            return RedirectToAction("AdminAgregaMotivo");
        }

        public ActionResult AdminEliminaMotivo()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarMotivoReporte());
        }

        public ActionResult deleteMotivo(int idMotivo)
        {
            MotivoReporteModel motivo = new MotivoReporteModel();
            motivo.MOT_ID = idMotivo;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.eliminarMotivo(motivo);
            return RedirectToAction("AdminEliminaMotivo");
        }

        public ActionResult AdminActualizaMotivo()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarMotivoReporte());
        }

        public ActionResult updateMotivo(int idMotivo, string nombreMotivo)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            MotivoReporteModel motivo = new MotivoReporteModel();
            motivo.MOT_ID = idMotivo;
            motivo.MOT_MotivoReporte = nombreMotivo;
            admin.actualizarMotivo(motivo);
            return RedirectToAction("AdminActualizaMotivo");
        }

    }
}
