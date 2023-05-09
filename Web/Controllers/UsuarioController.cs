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
        public ActionResult InicioUsuario()
        {
            var modelo = new ContenidoModel();
            modelo.persona = new PersonaModel();
            modelo.persona.PER_Correo = Request.Cookies["CorreoPersona"];
            AdministradorDatos admin = new AdministradorDatos(connection);
            UsuarioDatos usuario = new UsuarioDatos(connection);
            modelo.persona = usuario.listarDatosUsuario(modelo.persona);
            modelo.publicaciones = admin.listarPublicaciones();
            return View(modelo);
        }

        public ActionResult CrearPublicacion()
        {
            UsuarioDatos usuario = new UsuarioDatos(connection);
            List<TipoPublicacionModel> tipoPublicacion = usuario.listarTipoPublicacion();
            List<TipoElementoModel> tipoElemento = usuario.listarTipoElementos();
            ViewBag.tipoPublicaciones = new SelectList(tipoPublicacion, "TIPUBLI_ID", "TIPUBLI_Tipo");
            ViewBag.tipoElementos = new SelectList(tipoElemento, "TIPELEM_ID", "TIPELEM_Nombre");
            return View();
        }

        public ActionResult CrearPublicacionElementos(ContenidoModel contenido)
        {
            UsuarioDatos usuario = new UsuarioDatos(connection);
            usuario.InsertarPublicacionArticulo(contenido);
            return RedirectToAction("CrearPublicacion");
        }
    }
}
