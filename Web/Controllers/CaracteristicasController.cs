using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class CaracteristicasController : Controller
    {
        private readonly MySqlConnection connection;

        public CaracteristicasController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaCaracteristica()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarCaracteristicas());
        }

        public ActionResult insertCaracteristicas(int idCaracteristica, string peso, string comportamiento, string alimentacion)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            CaracteristicasModel caracteristicaModel = new CaracteristicasModel();
            caracteristicaModel.CARAC_ID = idCaracteristica;
            caracteristicaModel.CARAC_Peso = peso;
            caracteristicaModel.CARAC_Comportamiento = comportamiento;
            caracteristicaModel.CARAC_Alimentacion = alimentacion;
            admin.insertarCaracteristica(caracteristicaModel);
            return RedirectToAction("AdminAgregaCaracteristica");
        }

        public ActionResult AdminEliminaCaracteristicas()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarCaracteristicas());
        }

        public ActionResult deleteCaracteristicas(int idCaracteristica)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            CaracteristicasModel caracteristicaModel = new CaracteristicasModel();
            caracteristicaModel.CARAC_ID = idCaracteristica;
            admin.eliminarCaracteristica(caracteristicaModel);
            return RedirectToAction("AdminEliminaCaracteristicas");
        }

        public ActionResult AdminActualizaCaracteristicas()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarCaracteristicas());
        }

        public ActionResult updateCaracteristicas(int idCaracteristica, string peso, string comportamiento, string alimentacion)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            CaracteristicasModel caracteristicaModel = new CaracteristicasModel();
            caracteristicaModel.CARAC_ID = idCaracteristica;
            caracteristicaModel.CARAC_Peso = peso;
            caracteristicaModel.CARAC_Comportamiento = comportamiento;
            caracteristicaModel.CARAC_Alimentacion = alimentacion;
            admin.actualizarCaracteristica(caracteristicaModel);
            return RedirectToAction("AdminActualizaCaracteristicas");
        }

    }
}
