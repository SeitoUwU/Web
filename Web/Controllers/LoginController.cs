using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly MySqlConnection connection;
        public LoginController(MySqlConnection connection)
        {
            this.connection = connection;
        }

        // GET: LogonController
        public ActionResult Login()
        {
            return View();
        }

        public IActionResult RecuperacionContrasenia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperacionContrasenia(PersonaModel personaModel)
        { 
            LoginDatos loginDatos = new LoginDatos(connection);
            loginDatos.ActualizarContrasenia(personaModel);
            return RedirectToAction("RecuperacionContrasenia");
        }
        [HttpGet]
        public IActionResult RegistroPersona()
        {
            LoginDatos login = new LoginDatos(connection);
            List<TipoDocumentoModel> tipoDocumento = login.enlistarDocumento();
            ViewBag.TipoDocumento = new SelectList(tipoDocumento, "TIPDOC_ID", "TIPDOC_Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistroPersona(PersonaModel persona)
        {
            LoginDatos login = new LoginDatos(connection);
            login.registrarPersona(persona);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(PersonaModel persona)
        {
            LoginDatos log = new LoginDatos(connection);
            if (log.buscarUsuario(persona))
            {
                string rol = log.tomarRol(persona);
                if (rol == "Administrador")
                {
                    return RedirectToAction("AdminHome", "Administrador");
                } else if (rol == "Usuario")
                {
                    
                    return RedirectToAction("InicioUsuario", "Usuario");
                }
            }
            return View();
        }
    }
}
