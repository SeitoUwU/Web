using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class ReportesPublicacion : Controller
    {

        private readonly MySqlConnection connection;

        public ReportesPublicacion(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminReportes()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            List<PublicacionModel> publicaciones = admin.listarPublicaciones();
            return View(publicaciones);
        }

        [HttpPost]
        public ActionResult DesactivarPublicacion(int id)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.DesactivarPublicacion(id);
            return RedirectToAction("AdminReportes");
        }
    }
}
