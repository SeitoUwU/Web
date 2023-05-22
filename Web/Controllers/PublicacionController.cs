using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class PublicacionController : Controller
    {
        private readonly MySqlConnection connection;

        public PublicacionController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult CrearPublicacion(ContenidoModel contenido)
        {
           
            UsuarioDatos usuario = new UsuarioDatos(connection);
            AdministradorDatos admin = new AdministradorDatos(connection);
            List<TipoPublicacionModel> tipoPublicacion = usuario.listarTipoPublicacion();
            List<TipoElementoModel> tipoElemento = usuario.listarTipoElementos();
            List<TipoMascotaModel> tipoMascota = admin.listarTipoMascota();
            List<TipoVacunaModel> tipoVacuna = admin.listarTipoVacuna();
            List<GeneroMascotaModel> generoMascota = admin.listarGeneroMascotas();
            List<CaracteristicasModel> caracteristicas = admin.listarCaracteristicas();
            List<TipoCirugiaModel> tipoCirugia = admin.listarTipoCirugia();
            List<TipoAlergiaModel> tipoAlergia = admin.listarTipoAlergia();
            List<TipoTratamientoModel> tipoTratamiento = admin.listarTipoTratamiento();
            

            ViewBag.tipoPublicaciones = new SelectList(tipoPublicacion, "TIPUBLI_ID", "TIPUBLI_Tipo");
            ViewBag.tipoElementos = new SelectList(tipoElemento, "TIPELEM_ID", "TIPELEM_Nombre");
            ViewBag.tipoMascotas = new SelectList(tipoMascota, "TIPMASC_ID", "TIPMASC_Nombre");
            ViewBag.tipoVacunas = new SelectList(tipoVacuna, "TIPVAC_ID", "TIPVAC_Nombre");
            ViewBag.generoMascotas = new SelectList(generoMascota, "GENMASC_ID", "GENMASC_Nombre");
            ViewBag.caracteristicas = new SelectList(caracteristicas, "CARAC_ID", "Carac_caracteristicas");
            ViewBag.tipoCirugias = new SelectList(tipoCirugia, "TIPCIRU_ID", "TIPCIRU_Nombre");
            ViewBag.tipoAlergias = new SelectList(tipoAlergia, "TIPALER_ID", "TIPALER_Nombre");
            ViewBag.tipoTratamientos = new SelectList(tipoTratamiento, "TIPTRAT_ID", "TIPTRAT_Nombre");
            
          
            return View();
        }

        public ActionResult CrearPublicacionElementos(ContenidoModel contenido, IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    imagen.CopyTo(ms);
                    contenido.Imagen = ms.ToArray();
                }
            }

            string correo = Request.Cookies["CorreoPersona"];
            UsuarioDatos usuario = new UsuarioDatos(correo, connection);
            usuario.InsertarPublicacionArticulo(contenido);
            return RedirectToAction("InicioUsuario", "Usuario");
        }
        public ActionResult CrearPublicacionMascota(ContenidoModel contenido, IFormFile imagen)

        {
            if (imagen != null && imagen.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    imagen.CopyTo(ms);
                    contenido.Imagen = ms.ToArray();
                }
            }

            string correo = Request.Cookies["CorreoPersona"];
            UsuarioDatos usuario = new UsuarioDatos(correo, connection);
            usuario.InsertarPublicacionMascota(contenido);
            return RedirectToAction("InicioUsuario", "Usuario");
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
