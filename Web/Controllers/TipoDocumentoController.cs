using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private readonly MySqlConnection connection;

        public TipoDocumentoController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTipoDocumento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoDocumento());
        }

        public ActionResult createTipoDocumento(int idTipoDocumento, string nombreTipoDocumento)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoDocumentoModel tipoDocumentoModel = new TipoDocumentoModel();
            tipoDocumentoModel.TIPDOC_ID = idTipoDocumento;
            tipoDocumentoModel.TIPDOC_Nombre = nombreTipoDocumento;
            admin.insertarTipoDocumento(tipoDocumentoModel);
            return RedirectToAction("AdminAgregaTipoDocumento");
        }

        public ActionResult AdminEliminaTipoDocumento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoDocumento());
        }

        public ActionResult deleteTipoDocumento(int idTipoDocumento)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoDocumentoModel tipoDocumentoModel = new TipoDocumentoModel();
            tipoDocumentoModel.TIPDOC_ID = idTipoDocumento;
            admin.eliminarTipoDocumento(tipoDocumentoModel);
            return RedirectToAction("AdminEliminaTipoDocumento");
        }

        public ActionResult AdminActualizaTipoDocumento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoDocumento());
        }

        public ActionResult updateTipoDocumento(int idTipoDocumento, string nombreTipoDocumento)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoDocumentoModel tipoDocumentoModel = new TipoDocumentoModel();
            tipoDocumentoModel.TIPDOC_ID = idTipoDocumento;
            tipoDocumentoModel.TIPDOC_Nombre = nombreTipoDocumento;
            admin.actualizarTipoDocumento(tipoDocumentoModel);
            return RedirectToAction("AdminActualizaTipoDocumento");
        }

    }
}
