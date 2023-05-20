using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Web.Controllers
{
    public class TipoMascotaController : Controller
    {
        private readonly MySqlConnection connection;

        public TipoMascotaController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTipoMascota()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoMascota());
        }

        public ActionResult createTipoMascota(int idTipoMascota, string nombreTipoMascota)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoMascotaModel tipoMascotaModel = new TipoMascotaModel();
            tipoMascotaModel.TIPMASC_ID = idTipoMascota;
            tipoMascotaModel.TIPMASC_Nombre = nombreTipoMascota;
            admin.insertarTipoMascota(tipoMascotaModel);
            return RedirectToAction("AdminAgregaTipoMascota");
        }

        public ActionResult AdminEliminaTipoMascota()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoMascota());
        }

        public ActionResult deleteTipoMascota(int idTipoMascota)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoMascotaModel tipoMascotaModel = new TipoMascotaModel();
            tipoMascotaModel.TIPMASC_ID = idTipoMascota;
            admin.eliminarTipoMascota(tipoMascotaModel);
            return RedirectToAction("AdminEliminaTipoMascota");
        }

        public ActionResult AdminActualizaTipoMascota()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoMascota());
        }

        public ActionResult updateTipoMascota(int idTipoMascota, string nombreTipoMascota)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoMascotaModel tipoMascotaModel = new TipoMascotaModel();
            tipoMascotaModel.TIPMASC_ID = idTipoMascota;
            tipoMascotaModel.TIPMASC_Nombre = nombreTipoMascota;
            admin.actualizarTipoMascota(tipoMascotaModel);
            return RedirectToAction("AdminActualizaTipoMascota");
        }
    }
}
