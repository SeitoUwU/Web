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
            UsuarioDatos usuario = new UsuarioDatos(connection);
            modelo.persona = usuario.listarDatosUsuario(modelo.persona);
            modelo.publicaciones = usuario.listarPublicaciones();
            return View(modelo);
        }

        public ActionResult CrearPublicacion()
        {
            UsuarioDatos usuario = new UsuarioDatos(connection);
            AdministradorDatos admin = new AdministradorDatos(connection);
            List<TipoPublicacionModel> tipoPublicacion = usuario.listarTipoPublicacion();
            List<TipoElementoModel> tipoElemento = usuario.listarTipoElementos();
            List<TipoMascotaModel> tipoMascota = admin.listarTipoMascota();
            List<TipoVacunaModel> tipoVacuna = admin.listarTipoVacuna();


            ViewBag.tipoPublicaciones = new SelectList(tipoPublicacion, "TIPUBLI_ID", "TIPUBLI_Tipo");
            ViewBag.tipoElementos = new SelectList(tipoElemento, "TIPELEM_ID", "TIPELEM_Nombre");
            ViewBag.tipoMascotas = new SelectList(tipoMascota, "TIPMASC_ID", "TIPMASC_Nombre");
            ViewBag.tipoVacunas = new SelectList(tipoVacuna, "TIPVAC_ID", "TIPVAC_Nombre");
            return View();
        }

        public ActionResult CrearPublicacionElementos(ContenidoModel contenido)
        {
            string correo = Request.Cookies["CorreoPersona"];
            UsuarioDatos usuario = new UsuarioDatos(correo, connection);
            usuario.InsertarPublicacionArticulo(contenido);
            return RedirectToAction("InicioUsuario");
        }

        public ActionResult CrearPublicacionMascota(ContenidoModel contenido)
        {
            return RedirectToAction("InicioUsuario");
        }

        public IActionResult cargarTipoRazas(int id)
        {
            UsuarioDatos usuario = new UsuarioDatos(connection);
            List<TipoRazaModel> tipoRaza = usuario.listarTipoRazaPorId(id);
            ViewBag.tipoRazas = new SelectList(tipoRaza, "TIPRAZA_ID", "TIPRAZA_Nombre");
            return PartialView("_selectsDinamicos");
        }

        public IActionResult cargarVacunas(int id)
        {
            UsuarioDatos usuario = new UsuarioDatos(connection);
            List<VacunaModel> vacuna = usuario.listarVacunasPorId(id);
            ViewBag.vacunas = new SelectList(vacuna, "TIPRAZA_ID", "TIPRAZA_Nombre");
            return PartialView("_selectsDinamicos");
        }


    }
}
