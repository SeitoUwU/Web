using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public IActionResult RecuperacionContrasenia()
        {
            return View();
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

        // GET: LogonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LogonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LogonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LogonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LogonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
