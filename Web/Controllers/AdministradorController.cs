using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
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
        public ActionResult AdminHome()
        {
            return View();
        }
    }
}
