using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly MySqlConnection connection;

        public AdministradorController(MySqlConnection connection)
        {
            this.connection = connection;
        }


        // GET: AdministradorController
        public ActionResult AdminHome()
        {
            return View();
        }

        // GET: AdministradorController/Details/5
        public ActionResult AdminAgregaPais()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listaPaises());
        }

        [HttpPost]
        public ActionResult createPais(int idPais, string nombrePais)
        {
            PaisModel pais = new PaisModel();
            pais.PAIS_ID = idPais;
            pais.PAIS_Nombre = nombrePais;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.insertarPais(pais);
            return RedirectToAction("AdminAgregaPais");
        }

        public ActionResult AdminActualizaPais()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listaPaises());
        }

        public ActionResult ActualizarPais(int idPais, string nombrePais)
        {
            PaisModel pais = new PaisModel();
            pais.PAIS_ID = idPais;
            pais.PAIS_Nombre = nombrePais;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.ActualizarPais(pais);
            return RedirectToAction("AdminActualizaPais");
        }

        public ActionResult AdminEliminaPais()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listaPaises());
        }

        public ActionResult deletePais(int idPais)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            PaisModel pais = new PaisModel();
            pais.PAIS_ID = idPais;
            admin.EliminarPais(pais);
            return RedirectToAction("AdminEliminaPais");
        }

        public ActionResult AdminAgregaDepartamento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            var modelo = new ContenidoModel();
            modelo.departamentos = admin.listarDepartamentos();
            modelo.paises = admin.listaPaises();
            return View(modelo);
        }

        public ActionResult InsertarDepartamento(int idDepartamento, string nombreDepartamento, int paisSeleccionado)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            DepartamentoModel departamento = new DepartamentoModel();
            departamento.DEP_ID = idDepartamento;
            departamento.DEP_Nombre = nombreDepartamento;
            departamento.FKPAIS_ID = paisSeleccionado;
            admin.insertarDepartamentos(departamento);
            return RedirectToAction("AdminAgregaDepartamento");

        }

        public ActionResult AdminActualizaDepartamento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            var modelo = new ContenidoModel();
            modelo.departamentos = admin.listarDepartamentos();
            modelo.paises = admin.listaPaises();
            return View(modelo);
        }

        public ActionResult updateDepartamento(int paisSeleccionado, int idDepartamento, string nombreDepartamento)
        {
            DepartamentoModel dep = new DepartamentoModel();
            AdministradorDatos admin = new AdministradorDatos(connection);
            dep.DEP_ID = idDepartamento;
            dep.DEP_Nombre = nombreDepartamento;
            dep.FKPAIS_ID = paisSeleccionado;
            admin.ActualizarDepartamento(dep);
            return RedirectToAction("AdminActualizaDepartamento");
        }

        public ActionResult AdminEliminaDepartamento()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarDepartamentos());
        }

        public ActionResult deleteDepartamento(int idDepartamento)
        { 
            AdministradorDatos admin = new AdministradorDatos(connection);
            DepartamentoModel departamento = new DepartamentoModel();
            departamento.DEP_ID = idDepartamento;
            admin.EliminarDepartamento(departamento);
            return RedirectToAction("AdminEliminaDepartamento");
        }

        public ActionResult AdminAgregaMunicipio()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            var modelo = new ContenidoModel();
            modelo.municipios = admin.listarmunicipios();
            modelo.departamentos = admin.listarDepartamentos();
            return View(modelo);
        }

        public ActionResult createMunicipio(int idMunicipio, string nombreMunicipio, int idDepartamento)
        {
            MunicipioModel municipio = new MunicipioModel();
            municipio.MUN_ID = idMunicipio;
            municipio.MUN_Nombre = nombreMunicipio;
            municipio.FKDEP_ID = idDepartamento;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.InsertarMunicipio(municipio);
            return RedirectToAction("AdminAgregaMunicipio");
        }

        public ActionResult AdminEliminaMunicipio()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            var modelo = new ContenidoModel();
            modelo.municipios = admin.listarmunicipios();
            modelo.departamentos = admin.listarDepartamentos();
            return View(modelo);
        }
        
    }
}
