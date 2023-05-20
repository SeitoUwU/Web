using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class BarrioController : Controller
    {
        private readonly MySqlConnection connection;

        public BarrioController(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public ActionResult AdminAgregaBarrio()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            var modelo = new ContenidoModel();
            modelo.barrios = admin.listarBarrios();
            modelo.municipios = admin.listarmunicipios();
            return View(modelo);
        }

        public ActionResult createBarrio(int idBarrio, string nombreBarrio, int idMunicipio)
        {
            BarrioModel barrio = new BarrioModel();
            barrio.BAR_ID = idBarrio;
            barrio.BAR_Nombre = nombreBarrio;
            barrio.FKMUN_ID = idMunicipio;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.insertarBarrio(barrio);
            return RedirectToAction("AdminAgregaBarrio");
        }

        public ActionResult AdminEliminaBarrio()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarBarrios());
        }

        public ActionResult deleteBarrio(int idBarrio)
        {
            BarrioModel barrio = new BarrioModel();
            barrio.BAR_ID = idBarrio;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.eliminarBarrio(barrio);
            return RedirectToAction("AdminEliminaBarrio");
        }

        public ActionResult AdminActualizaBarrio()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            var modelo = new ContenidoModel();
            modelo.barrios = admin.listarBarrios();
            modelo.municipios = admin.listarmunicipios();
            return View(modelo);
        }

        public ActionResult updateBarrio(int idBarrio, string nombreBarrio, int idMunicipio)
        {
            BarrioModel barrio = new BarrioModel();
            barrio.BAR_ID = idBarrio;
            barrio.BAR_Nombre = nombreBarrio;
            barrio.FKMUN_ID = idMunicipio;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.ActualizarBarrio(barrio);
            return RedirectToAction("AdminActualizaBarrio");
        }

    }
}
