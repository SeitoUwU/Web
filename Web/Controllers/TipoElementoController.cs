using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class TipoElementoController : Controller
    {
        private readonly MySqlConnection connection;

        public TipoElementoController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTipoElemento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoElemento());
        }

        public ActionResult createTipoElemento(int idTipoElemento, string nombreTipoElemento)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoElementoModel tipoElementoModel = new TipoElementoModel();
            tipoElementoModel.TIPELEM_ID = idTipoElemento;
            tipoElementoModel.TIPELEM_Nombre = nombreTipoElemento;
            admin.insertarTipoElemento(tipoElementoModel);
            return RedirectToAction("AdminAgregaTipoElemento");
        }

        public ActionResult AdminEliminaTipoElemento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoElemento());
        }

        public ActionResult deleteTipoElemento(int idTipoElemento)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoElementoModel tipoElementoModel = new TipoElementoModel();
            tipoElementoModel.TIPELEM_ID = idTipoElemento;
            admin.eliminarTipoElemento(tipoElementoModel);
            return RedirectToAction("AdminEliminaTipoElemento");
        }

        public ActionResult AdminActualizaTipoElemento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoElemento());
        }

        public ActionResult updateTipoElemento(int idTipoElemento, string nombreTipoElemento)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoElementoModel tipoElementoModel = new TipoElementoModel();
            tipoElementoModel.TIPELEM_ID = idTipoElemento;
            tipoElementoModel.TIPELEM_Nombre = nombreTipoElemento;
            admin.actualizarTipoElemento(tipoElementoModel);
            return RedirectToAction("AdminActualizaTipoElemento");
        }

    }
}
