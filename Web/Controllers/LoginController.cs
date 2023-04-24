using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly MySqlConnection connection;
        public LoginController(MySqlConnection mySql)
        {
            connection = mySql;
        }
        public IActionResult IniciarSesion()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Log(PersonaModel persona)
        {
            LoginDatos log = new LoginDatos(connection);
            Boolean bandera = log.buscarUsuario(persona);
            if (bandera)
            {
                return View();
            }
            else
            {

            }
            return View();
        }
    }
}
