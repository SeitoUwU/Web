using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class TipoVacuna : Controller
    {
        private readonly MySqlConnection connection;

        public TipoVacuna(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTipoVacuna()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoVacuna());
        }

        public ActionResult createTipoVacuna(int idTipoVacuna, string nombreTipoVacuna)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoVacunaModel tipoVacunaModel = new TipoVacunaModel();
            tipoVacunaModel.TIPVAC_ID = idTipoVacuna;
            tipoVacunaModel.TIPVAC_Nombre = nombreTipoVacuna;
            admin.insertarTipoVacuna(tipoVacunaModel);
            return RedirectToAction("AdminAgregaTipoVacuna");
        }

        public ActionResult AdminEliminaTipoVacuna()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoVacuna());
        }

        public ActionResult deleteTipoVacuna(int idTipoVacuna)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoVacunaModel tipoVacunaModel = new TipoVacunaModel();
            tipoVacunaModel.TIPVAC_ID = idTipoVacuna;
            admin.eliminarTipoVacuna(tipoVacunaModel);
            return RedirectToAction("AdminEliminaTipoVacuna");
        }

        public ActionResult AdminActualizaTipoVacuna()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoVacuna());
        }

        public ActionResult updateTipoVacuna(int idTipoVacuna, string nombreTipoVacuna)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoVacunaModel tipoVacunaModel = new TipoVacunaModel();
            tipoVacunaModel.TIPVAC_ID = idTipoVacuna;
            tipoVacunaModel.TIPVAC_Nombre = nombreTipoVacuna;
            admin.actualizarTipoVacuna(tipoVacunaModel);
            return RedirectToAction("AdminActualizaTipoVacuna");
        }
    }
}
