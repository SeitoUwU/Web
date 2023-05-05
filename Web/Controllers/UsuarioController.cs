using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly MySqlConnection connection;

        public UsuarioController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        // GET: UsuarioController
        public ActionResult InicioUsuario()
        {
            UsuarioDatos usuario = new UsuarioDatos(connection);
            PersonaModel persona = new PersonaModel();
            persona.PER_Correo = Request.Cookies["CorreoPersona"];
            usuario.listarDatosUsuario(persona);
            return View(persona);
        }
    }
}
