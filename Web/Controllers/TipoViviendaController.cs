using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class TipoViviendaController : Controller
    {
        private readonly MySqlConnection connection;

        public TipoViviendaController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTipoVivienda()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoVivienda());
        }

        public ActionResult createTipoVivienda(int idTipoVivienda, string nombreTipoVivienda)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoViviendaModel tipoViviendaModel = new TipoViviendaModel();
            tipoViviendaModel.TIPVIVI_ID = idTipoVivienda;
            tipoViviendaModel.TIPVIVI_Vivienda = nombreTipoVivienda;
            admin.insertarTipoVivienda(tipoViviendaModel);
            return RedirectToAction("AdminAgregaTipoVivienda");
        }

        public ActionResult AdminEliminaTipoVivienda()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoVivienda());
        }

        public ActionResult deleteTipoVivienda(int idTipoVivienda)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoViviendaModel tipoViviendaModel = new TipoViviendaModel();
            tipoViviendaModel.TIPVIVI_ID = idTipoVivienda;
            admin.eliminarTipoVivienda(tipoViviendaModel);
            return RedirectToAction("AdminEliminaTipoVivienda");
        }

        public ActionResult AdminActualizaTipoVivienda()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoVivienda());
        }

        public ActionResult updateTipoVivienda(int idTipoVivienda, string nombreTipoVivienda)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoViviendaModel tipoViviendaModel = new TipoViviendaModel();
            tipoViviendaModel.TIPVIVI_ID = idTipoVivienda;
            tipoViviendaModel.TIPVIVI_Vivienda = nombreTipoVivienda;
            admin.actualizarTipoVivienda(tipoViviendaModel);
            return RedirectToAction("AdminActualizaTipoVivienda");
        }


    }
}
