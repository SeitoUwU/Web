using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly MySqlConnection connection;

        public AdministradorController(MySqlConnection connection)
        {
            this.connection = connection;
        }


        // GET: AdministradorController
        public ActionResult AdminHome()
        {
            return View();
        }

        // GET: AdministradorController/Details/5
        public ActionResult AdminAgregaPais()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listaPaises());
        }

        [HttpPost]
        public ActionResult createPais(int idPais, string nombrePais)
        {
            PaisModel pais = new PaisModel();
            pais.PAIS_ID = idPais;
            pais.PAIS_Nombre = nombrePais;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.insertarPais(pais);
            return RedirectToAction("AdminAgregaPais");
        }
        
    }
}
