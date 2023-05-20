using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class RolController : Controller
    {
        private readonly MySqlConnection connection;

        public RolController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaRol()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarRoles());
        }

        public ActionResult createRol(int idRol, string nombreRol)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            RolModel rol = new RolModel();
            rol.ROL_ID = idRol;
            rol.ROL_Nombre = nombreRol;
            admin.insertarRol(rol);
            return RedirectToAction("AdminAgregaRol");
        }

        public ActionResult AdminEliminaRol()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarRoles());
        }

        public ActionResult DeleteRol(int idRol)
        {
            RolModel rol = new RolModel();
            rol.ROL_ID = idRol;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.eliminarRol(rol);
            return RedirectToAction("AdminEliminaRol");
        }

        public ActionResult AdminActualizaRol()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarRoles());
        }

        public ActionResult updateRol(int idRol, string nombreRol)
        {
            RolModel rol = new RolModel();
            rol.ROL_ID = idRol;
            rol.ROL_Nombre = nombreRol;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.actualizarRol(rol);
            return RedirectToAction("AdminActualizaRol");
        }
    }
}
