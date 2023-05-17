using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Web.Controllers
{
    public class OrganizacionController : Controller
    {
        private readonly MySqlConnection connection;
        public OrganizacionController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult Formulario()
        {
            return View();
        }
    }
}
