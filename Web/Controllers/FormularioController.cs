using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class FormularioController : Controller
    {
        private readonly MySqlConnection connection;
        public FormularioController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public IActionResult Formulario(int id)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            List<TipoViviendaModel> tipoVivienda = new List<TipoViviendaModel>();
            tipoVivienda = admin.listarTipoVivienda();
            ViewBag.tipoVivienda = new SelectList(tipoVivienda, "TIPVIVI_ID", "TIPVIVI_Vivienda");
            Response.Cookies.Append("idPublicacion", (id + ""));
            return View();
        }

        public ActionResult insertarFormulario(FormularioModel formulario)
        {
            OrganizacionDatos organizacion = new OrganizacionDatos(connection);

            UsuarioDatos usuario = new UsuarioDatos(connection);
            string correo = Request.Cookies["CorreoPersona"];
            int id = usuario.ObtenerIdPersonaPorCorreo(correo);
            int.TryParse(Request.Cookies["idPublicacion"], out int idPublicacion);
           organizacion.insertarFormulario(formulario, id, idPublicacion);
            return RedirectToAction("InicioUsuario", "Usuario");
        }
    }
}
