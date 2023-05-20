using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class TipoAlergiaController : Controller
    {
        private readonly MySqlConnection connection;

        public TipoAlergiaController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTipoAlergia()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoAlergia());
        }

        public ActionResult createTipoAlergia(int idTipoAlergia, string nombreTipoAlergia)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoAlergiaModel tipoAlergiaModel = new TipoAlergiaModel();
            tipoAlergiaModel.TIPALER_ID = idTipoAlergia;
            tipoAlergiaModel.TIPALER_Nombre = nombreTipoAlergia;
            admin.insertarTipoAlergia(tipoAlergiaModel);
            return RedirectToAction("AdminAgregaTipoAlergia");
        }

        public ActionResult AdminEliminaTipoAlergia()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoAlergia());
        }

        public ActionResult deleteTipoAlergia(int idTipoAlergia)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoAlergiaModel tipoAlergiaModel = new TipoAlergiaModel();
            tipoAlergiaModel.TIPALER_ID = idTipoAlergia;
            admin.eliminarTipoAlergia(tipoAlergiaModel);
            return RedirectToAction("AdminEliminaTipoAlergia");
        }

        public ActionResult AdminActualizaTipoAlergia()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoAlergia());
        }

        public ActionResult updateTipoAlergia(int idTipoAlergia, string nombreTipoAlergia)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoAlergiaModel tipoAlergiaModel = new TipoAlergiaModel();
            tipoAlergiaModel.TIPALER_ID = idTipoAlergia;
            tipoAlergiaModel.TIPALER_Nombre = nombreTipoAlergia;
            admin.actualizarTipoAlergia(tipoAlergiaModel);
            return RedirectToAction("AdminActualizaTipoAlergia");
        }

    }
}
