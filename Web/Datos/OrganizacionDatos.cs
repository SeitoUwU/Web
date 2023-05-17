using MySql.Data.MySqlClient;

namespace Web.Datos
{
    public class OrganizacionDatos
    {
        private readonly MySqlConnection connection;

        public OrganizacionDatos(MySqlConnection connection)
        {
            this.connection = connection;
        }
    }
}
