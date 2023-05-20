using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class TipoRazaController : Controller
    {
        private readonly MySqlConnection connection;

        public TipoRazaController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTipoRaza()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            var modelo = new ContenidoModel();
            modelo.tiposRaza = admin.listarTipoRaza();
            modelo.tiposMascota = admin.listarTipoMascota();
            return View(modelo);
        }

        public ActionResult createTipoRaza(int idTipoRaza, string nombreTipoRaza, int idTipoMascota)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoRazaModel tipoRazaModel = new TipoRazaModel();
            tipoRazaModel.TIPRAZA_ID = idTipoRaza;
            tipoRazaModel.TIPRAZA_Nombre = nombreTipoRaza;
            tipoRazaModel.FKTIPMASC_ID = idTipoMascota;
            admin.insertarTipoRaza(tipoRazaModel);
            return RedirectToAction("AdminAgregaTipoRaza");
        }

        public ActionResult AdminEliminaTipoRaza()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoRaza());
        }

        public ActionResult deleteTipoRaza(int idTipoRaza)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoRazaModel tipoRazaModel = new TipoRazaModel();
            tipoRazaModel.TIPRAZA_ID = idTipoRaza;
            admin.eliminarTipoRaza(tipoRazaModel);
            return RedirectToAction("AdminEliminaTipoRaza");
        }

        public ActionResult AdminActualizaTipoRaza()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            var modelo = new ContenidoModel();
            modelo.tiposRaza = admin.listarTipoRaza();
            modelo.tiposMascota = admin.listarTipoMascota();
            return View(modelo);
        }

        public ActionResult updateTipoRaza(int idTipoRaza, string nombreTipoRaza, int idTipoMascota)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoRazaModel tipoRazaModel = new TipoRazaModel();
            tipoRazaModel.TIPRAZA_ID = idTipoRaza;
            tipoRazaModel.TIPRAZA_Nombre = nombreTipoRaza;
            tipoRazaModel.FKTIPMASC_ID = idTipoMascota;
            admin.actualizarTipoRaza(tipoRazaModel);
            return RedirectToAction("AdminActualizaTipoRaza");
        }

    }
}
