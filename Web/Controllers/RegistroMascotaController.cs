using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class RegistroMascotaController : Controller
    {
        public readonly MySqlConnection Connection;

        public RegistroMascotaController(MySqlConnection mySql)
        {
            Connection = mySql;
        }

        // GET: RegistroMascotaController
        public ActionResult Registro()
        {
            RegistroMascotaDatos registro = new RegistroMascotaDatos(Connection);
            List<TipoMascotaModel> tipoMascota = registro.TipoMascota();
            ViewBag.TipoMascota = new SelectList(tipoMascota, "TIPMASC_ID", "TIPMASC_Nombre");
            List<CaracteristicasModel> caracteristicas = registro.caracteristicas();
            ViewBag.CaracteristicasMascota = new SelectList(caracteristicas, "CARAC_ID", "Carac_caracteristicas");
            List<TipoRazaModel> tipoRazas = registro.tipoRazas();
            ViewBag.TipoRazas = new SelectList(tipoRazas, "TIPRAZA_ID", "TIPRAZA_Nombre");
            List<GeneroMascotaModel> generoMascotas = registro.generoMascotas();
            ViewBag.GeneroMascotas = new SelectList(generoMascotas, "GENMASC_ID", "GENMASC_Nombre");
            return View();
        }

        // GET: RegistroMascotaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistroMascotaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MascotaModel mascota)
        {
            RegistroMascotaDatos registro = new RegistroMascotaDatos(Connection);
            registro.RegistrarMascota(mascota);
            return View();
        }

      

        // GET: RegistroMascotaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        

        // GET: RegistroMascotaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

       
    }
}
