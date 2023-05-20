using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class TipoGrupoController : Controller
    {
        private readonly MySqlConnection connection;

        public TipoGrupoController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTpoGrupo()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoGrupo());
        }

        public ActionResult createTipoGrupo(int idTipoGrupo, string nombreTipoGrupo)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoGrupoModel tipoGrupoModel = new TipoGrupoModel();
            tipoGrupoModel.TIPGRUP_ID = idTipoGrupo;
            tipoGrupoModel.TIPGRUP_Nombre = nombreTipoGrupo;
            admin.insertarTipoGrupo(tipoGrupoModel);
            return RedirectToAction("AdminAgregaTpoGrupo");
        }

        public ActionResult AdminEliminaTipoGrupo()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoGrupo());
        }

        public ActionResult deleteTipoGrupo(int idTipoGrupo)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoGrupoModel tipoGrupoModel = new TipoGrupoModel();
            tipoGrupoModel.TIPGRUP_ID = idTipoGrupo;
            admin.eliminarTipoGrupo(tipoGrupoModel);
            return RedirectToAction("AdminEliminaTipoGrupo");
        }

        public ActionResult AdminActualizaTipoGrupo()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoGrupo());
        }

        public ActionResult updateTipoGrupo(int idTipoGrupo, string nombreTipoGrupo)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoGrupoModel tipoGrupoModel = new TipoGrupoModel();
            tipoGrupoModel.TIPGRUP_ID = idTipoGrupo;
            tipoGrupoModel.TIPGRUP_Nombre = nombreTipoGrupo;
            admin.actualizarTipoGrupo(tipoGrupoModel);
            return RedirectToAction("AdminActualizaTipoGrupo");
        }

    }
}
