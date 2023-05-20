using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class MunicipioController : Controller
    {
        private readonly MySqlConnection connection;

        public MunicipioController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaMunicipio()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            var modelo = new ContenidoModel();
            modelo.municipios = admin.listarmunicipios();
            modelo.departamentos = admin.listarDepartamentos();
            return View(modelo);
        }

        public ActionResult createMunicipio(int idMunicipio, string nombreMunicipio, int idDepartamento)
        {
            MunicipioModel municipio = new MunicipioModel();
            municipio.MUN_ID = idMunicipio;
            municipio.MUN_Nombre = nombreMunicipio;
            municipio.FKDEP_ID = idDepartamento;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.InsertarMunicipio(municipio);
            return RedirectToAction("AdminAgregaMunicipio");
        }

        public ActionResult AdminEliminaMunicipio()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarmunicipios());
        }

        public ActionResult deleteMunicipio(int idMunicipio)
        {
            MunicipioModel municipio = new MunicipioModel();
            municipio.MUN_ID = idMunicipio;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.EliminarMunicipio(municipio);
            return RedirectToAction("AdminEliminaMunicipio");
        }

        public ActionResult AdminActualizaMunicipio()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            var modelo = new ContenidoModel();
            modelo.municipios = admin.listarmunicipios();
            modelo.departamentos = admin.listarDepartamentos();
            return View(modelo);
        }

        public ActionResult updateMunicipio(int idMunicipio, string nombreMunicipio, int idDepartamento)
        {
            MunicipioModel municipio = new MunicipioModel();
            municipio.MUN_ID = idMunicipio;
            municipio.MUN_Nombre = nombreMunicipio;
            municipio.FKDEP_ID = idDepartamento;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.ActualizarMunicipio(municipio);
            return RedirectToAction("AdminActualizaMunicipio");
        }
    }
}
