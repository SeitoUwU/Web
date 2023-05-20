using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly MySqlConnection connection;

        public DepartamentoController(MySqlConnection connection)
        {
            this.connection = connection;
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

    }
}
