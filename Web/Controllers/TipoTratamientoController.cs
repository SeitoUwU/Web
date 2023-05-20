using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Web.Controllers
{
    public class TipoTratamientoController : Controller
    {

        private readonly MySqlConnection connection;

        public TipoTratamientoController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTipoTratamiento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoTratamiento());
        }

        public ActionResult createTipoTratamiento(int idTipoTratamiento, string nombreTipoTratamiento)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoTratamientoModel tipoTratamientoModel = new TipoTratamientoModel();
            tipoTratamientoModel.TIPTRAT_ID = idTipoTratamiento;
            tipoTratamientoModel.TIPTRAT_Nombre = nombreTipoTratamiento;
            admin.insertarTipoTratamiento(tipoTratamientoModel);
            return RedirectToAction("AdminAgregaTipoTratamiento");
        }

        public ActionResult AdminEliminaTipoTratamiento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoTratamiento());
        }

        public ActionResult deleteTipoTratamiento(int idTipoTratamiento)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoTratamientoModel tipoTratamientoModel = new TipoTratamientoModel();
            tipoTratamientoModel.TIPTRAT_ID = idTipoTratamiento;
            admin.eliminarTipoTratamiento(tipoTratamientoModel);
            return RedirectToAction("AdminEliminaTipoTratamiento");
        }

        public ActionResult AdminActualizaTipoTratamiento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoTratamiento());
        }

        public ActionResult updateTipoTratamiento(int idTipoTratamiento, string nombreTipoTratamiento)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoTratamientoModel tipoTratamientoModel = new TipoTratamientoModel();
            tipoTratamientoModel.TIPTRAT_ID = idTipoTratamiento;
            tipoTratamientoModel.TIPTRAT_Nombre = nombreTipoTratamiento;
            admin.actualizarTipoTratamiento(tipoTratamientoModel);
            return RedirectToAction("AdminActualizaTipoTratamiento");
        }

    }
}
