using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;
using Web.Data;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly MySqlConnection connection;
        private readonly Contexto contexto;

        public UsuarioController(Contexto contexto)
        {
            this.contexto = contexto;
            connection = new MySqlConnection(contexto.Conexion);
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


        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }

        public ActionResult InformacionUsuario()
        {
            String correo = Request.Cookies["CorreoPersona"];
            ContenidoModel contenido = new ContenidoModel();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(contexto.Conexion))
                {
                    connection.Open();
                    using (MySqlCommand command = new("mostrarDatosUsuario", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@correo", correo);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            contenido.persona = new PersonaModel();
                            contenido.tipoDocumento = new TipoDocumentoModel();
                            contenido.pais = new PaisModel();
                            contenido.departamento = new DepartamentoModel();
                            contenido.municipio = new MunicipioModel();
                            contenido.barrio = new BarrioModel();

                            while (reader.Read())
                            {
                                contenido.persona.PER_NombreUno = reader.GetString(0);
                                contenido.persona.PER_NombreDos = reader.GetString(1);
                                contenido.persona.PER_ApellidoUno = reader.GetString(2);
                                contenido.persona.PER_ApellidoDos = reader.GetString(3);
                                contenido.persona.PER_Correo = reader.GetString(4);
                                contenido.persona.PER_DireccionVinda = reader.GetString(5);
                                contenido.persona.PER_NumeroDocumento = reader.GetInt32(6);
                                contenido.tipoDocumento.TIPDOC_Nombre = reader.GetString(7);
                                contenido.pais.PAIS_Nombre = reader.GetString(8);
                                contenido.departamento.DEP_Nombre = reader.GetString(9);
                                contenido.municipio.MUN_Nombre = reader.GetString(10);
                                contenido.barrio.BAR_Nombre = reader.GetString(11);
                            }
                        }
                    }
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }

            AdministradorDatos admin = new AdministradorDatos(connection);

            List<TipoDocumentoModel> tipoDocumentos = new List<TipoDocumentoModel>();
            List<PaisModel> paises = new List<PaisModel>();
            List<DepartamentoModel> departamentos = new List<DepartamentoModel>();
            List<MunicipioModel> municipios = new List<MunicipioModel>();
            List<BarrioModel> barrios = new List<BarrioModel>();

            tipoDocumentos = admin.listarTipoDocumento();
            paises = admin.listaPaises();
            departamentos = admin.listarDepartamentos();
            municipios = admin.listarmunicipios();
            barrios = admin.listarBarrios();

            ViewBag.tipoDocumentos = new SelectList(tipoDocumentos, "TIPDOC_ID", "TIPDOC_Nombre");
            ViewBag.paises = new SelectList(paises, "PAIS_ID", "PAIS_Nombre");
            ViewBag.departamentos = new SelectList(departamentos, "DEP_ID", "DEP_Nombre");
            ViewBag.municipios = new SelectList(municipios, "MUN_ID", "MUN_Nombre");
            ViewBag.barrios = new SelectList(barrios, "BAR_ID", "BAR_Nombre");
            return View(contenido);
        }
    }
}
