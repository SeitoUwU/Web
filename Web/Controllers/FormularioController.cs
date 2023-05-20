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
        public ActionResult Formulario()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            List<TipoViviendaModel> tipoVivienda = new List<TipoViviendaModel>();
            tipoVivienda = admin.listarTipoVivienda();
            ViewBag.tipoVivienda = new SelectList(tipoVivienda, "TIPVIVI_ID", "TIPVIVI_Vivienda");
            return View();
        }

        public ActionResult insertarFormulario(FormularioModel formulario)
        {
            OrganizacionDatos organizacion = new OrganizacionDatos(connection);
            organizacion.insertarFormulario(formulario);
            return RedirectToAction("InicioUsuario", "Usuario");
        }
    }
}
