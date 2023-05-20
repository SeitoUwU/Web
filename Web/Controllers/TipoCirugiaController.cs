using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class TipoCirugiaController : Controller
    {
        private readonly MySqlConnection connection;

        public TipoCirugiaController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaTipoCirugia()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoCirugia());
        }

        public ActionResult createTipoCirugia(int idTipoCirugia, string nombreTipoCirugia)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoCirugiaModel tipoCirugiaModel = new TipoCirugiaModel();
            tipoCirugiaModel.TIPCIRU_ID = idTipoCirugia;
            tipoCirugiaModel.TIPCIRU_Nombre = nombreTipoCirugia;
            admin.insertarTipoCirugia(tipoCirugiaModel);
            return RedirectToAction("AdminAgregaTipoCirugia");
        }

        public ActionResult AdminEliminaTipoCirugia()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoCirugia());
        }

        public ActionResult deleteTipoCirugia(int idTipoCirugia)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoCirugiaModel tipoCirugiaModel = new TipoCirugiaModel();
            tipoCirugiaModel.TIPCIRU_ID = idTipoCirugia;
            admin.eliminarTipoCirugia(tipoCirugiaModel);
            return RedirectToAction("AdminEliminaTipoCirugia");
        }

        public ActionResult AdminActualizaTipoCirugia()
        {
            ContenidoModel cont = new ContenidoModel();
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoCirugia());
        }

        public ActionResult updateTipoCirugia(int idTipoCirugia, string nombreTipoCirugia)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoCirugiaModel tipoCirugiaModel = new TipoCirugiaModel();
            tipoCirugiaModel.TIPCIRU_ID = idTipoCirugia;
            tipoCirugiaModel.TIPCIRU_Nombre = nombreTipoCirugia;
            admin.actualizarTipoCirugia(tipoCirugiaModel);
            return RedirectToAction("AdminActualizaTipoCirugia");
        }

    }
}
