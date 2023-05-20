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
        //[Authorize]
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
            ViewBag.vacunas = new SelectList(vacuna, "VAC_ID", "VAC_Nombre");
            return PartialView("_selectsDinamicos");
        }

        public IActionResult cargarAlergias(int id)
        {
            UsuarioDatos usuario = new UsuarioDatos(connection);
            List<AlergiaModel> alergia = usuario.listarAlergiasPorId(id);
            ViewBag.alergias = new SelectList(alergia, "ALER_ID", "ALER_NombreAlergia");
            return PartialView("_selectsDinamicos");
        }


    }
}
