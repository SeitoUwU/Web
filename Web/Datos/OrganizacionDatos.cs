using MySql.Data.MySqlClient;
using Web.Models;

namespace Web.Datos
{
    public class OrganizacionDatos
    {
        private readonly MySqlConnection connection;

        public OrganizacionDatos(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public Boolean insertarFormulario(FormularioModel formulario)
        {

            return false;
        }
    }
}
