using MySql.Data.MySqlClient;
using Web.Models;

namespace Web.Datos
{
    public class LoginDatos
    {
        private readonly MySqlConnection connection;
        private Boolean bandera = false;
        public LoginDatos(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public Boolean buscarUsuario(PersonaModel person)
        {
            connection.Open();
            string sql = "Select PER_Correo, " +
                "PER_Contrasenia from persona where PER_Correo = @correo and PER_Contrasenia = @contrasenia";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@correo", person.PER_Correo);
            command.Parameters.AddWithValue("@contrasenia", person.PER_Contrasenia);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bandera = true;
            }
            connection.Close();
            return bandera;
        }
    }
}
