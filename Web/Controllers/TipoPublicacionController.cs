using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class TipoPublicacionController : Controller
    {
        private readonly MySqlConnection connection;

        public TipoPublicacionController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTipoPublibacion()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoPublicacion());
        }

        public ActionResult createTipoPublicacion(int idTipoPublicacion, string nombreTipoPublicacion)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoPublicacionModel tipoPublicacionModel = new TipoPublicacionModel();
            tipoPublicacionModel.TIPUBLI_ID = idTipoPublicacion;
            tipoPublicacionModel.TIPUBLI_Tipo = nombreTipoPublicacion;
            admin.insertarTipoPublicacion(tipoPublicacionModel);
            return RedirectToAction("AdminAgregaTipoPublibacion");
        }

        public ActionResult AdminEliminaTipoPublicacion()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoPublicacion());
        }

        public ActionResult deleteTipoPublicacion(int idTipoPublicacion)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoPublicacionModel tipoPublicacionModel = new TipoPublicacionModel();
            tipoPublicacionModel.TIPUBLI_ID = idTipoPublicacion;
            admin.eliminarTipoPublicacion(tipoPublicacionModel);
            return RedirectToAction("AdminEliminaTipoPublicacion");
        }

        public ActionResult AdminActualizaTipoPublicacion()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoPublicacion());
        }

        public ActionResult updateTipoPublicacion(int idTipoPublicacion, string nombrePublicacion)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoPublicacionModel tipoPublicacionModel = new TipoPublicacionModel();
            tipoPublicacionModel.TIPUBLI_ID = idTipoPublicacion;
            tipoPublicacionModel.TIPUBLI_Tipo = nombrePublicacion;
            admin.actualizarTipoPublicacion(tipoPublicacionModel);
            return RedirectToAction("AdminActualizaTipoPublicacion");
        }

    }
}
