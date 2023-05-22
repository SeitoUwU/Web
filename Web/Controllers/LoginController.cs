using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using System.Security.Claims;
using Web.Data;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly MySqlConnection connection;
        private readonly Contexto contexto;
        
        public LoginController(Contexto contexto)
        {
            this.contexto = contexto;
            connection = new MySqlConnection(contexto.Conexion);
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
            return RedirectToAction("Login");
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
            return RedirectToActionPermanent("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(PersonaModel persona)
        {
            try
            {
                using (MySqlConnection connection = new (contexto.Conexion))
                {
                    connection.Open();
                    using (MySqlCommand command = new("login", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@correo", persona.PER_Correo);
                        command.Parameters.AddWithValue("@contrasenia", persona.PER_Contrasenia);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                int fkrol = reader.GetInt32(1);
                                string correo = reader.GetString(2);

                                Response.Cookies.Append("CorreoPersona", correo);

                                if (correo != null)
                                {
                                    List<Claim> claims = new List<Claim>()
                                    {
                                         new Claim(ClaimTypes.NameIdentifier, Convert.ToString(id)),
                                         new Claim(ClaimTypes.Role, Convert.ToString(fkrol)),
                                         new Claim("correoUsuario", correo)
                                    };

                                    ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                                    AuthenticationProperties authentication = new();

                                    authentication.AllowRefresh = true;
                                    authentication.IsPersistent = false;
                                    authentication.ExpiresUtc = DateTimeOffset.MaxValue;

                                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authentication);
                                    if (fkrol == 1) // ID del rol para administrador
                                    {
                                        return RedirectToAction("AdminMenu", "Usuario");
                                    }
                                    else if (fkrol == 2)// Otros roles
                                    {
                                        return RedirectToAction("InicioUsuario", "Usuario");
                                    }
                                }
                            }
                        }
                    }
                }
            }catch (Exception ex)
            {
                return View();
            }
            return View();
        }
    }
}
