using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Authorize]
        public ActionResult InicioUsuario()
        {
            var modelo = new ContenidoModel();
            modelo.persona = new PersonaModel();
            modelo.persona.PER_Correo = Request.Cookies["CorreoPersona"];
            UsuarioDatos usuario = new UsuarioDatos(connection);
            modelo.persona = usuario.listarDatosUsuario(modelo.persona);
            modelo.publicaciones = usuario.listarPublicaciones();
            return View(modelo);
        }


    }
}
