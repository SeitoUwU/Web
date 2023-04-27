using MySql.Data.MySqlClient;
using Web.Models;

namespace Web.Datos
{
    public class AdministradorDatos
    {
        private readonly MySqlConnection _connection;

        public AdministradorDatos(MySqlConnection connection)
        {
            _connection = connection;
        }

        public List<PaisModel> listaPaises()
        {
            _connection.Open();
            string sql = "select PAIS_ID, PAIS_Nombre from pais";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<PaisModel> paises = new List<PaisModel>();
            while (reader.Read())
            {
                PaisModel pais = new PaisModel();
                pais.PAIS_ID = reader.GetInt32(0);
                pais.PAIS_Nombre = reader.GetString(1);
                paises.Add(pais);
            }
            _connection.Close();
            return paises;
        }

        public Boolean insertarPais(PaisModel pais)
        {
            _connection.Open();
            string sql = "insert into pais(PAIS_ID, PAIS_Nombre) " + "values ('" + pais.PAIS_ID + "', '" + pais.PAIS_Nombre + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
    }
}
