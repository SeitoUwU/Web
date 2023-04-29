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
            var modelo = new DepMunModel();
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
        
    }
}
