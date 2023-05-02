using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
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
                tomarRol(person);
            }
            connection.Close();
            return bandera;
        }
        public Boolean ActualizarContrasenia(PersonaModel personaModel) 
        { 
            connection.Open();
             String sql = "update persona set PER_Contrasenia = '" + personaModel.PER_Contrasenia +
                "' where PER_Correo = '" + personaModel.PER_Correo + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public string tomarRol (PersonaModel person)
        {
            string rol = "";
            using (MySqlConnection connection = new MySqlConnection(connectionString: "Server=localhost;port=3306;database=adopcionmascotas;Uid=Usuarios;password=root;"))
            {
                connection.Open();
                string sql = "Select ROL_Nombre from rol inner join persona on FKROL_ID = ROL_ID and PER_Correo = @correo";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@correo", person.PER_Correo);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rol = reader.GetString("ROL_Nombre");
                }
            }
            return rol;
        }

        public Boolean registrarPersona(PersonaModel persona)
        {
            connection.Open();
            string sql = "insert into persona (PER_NombreUno, PER_ApellidoUno, PER_NumeroDocumento, PER_DireccionVivienda, " +
                "PER_Correo, PER_Contrasenia, FKROL_ID, FKTIPDOC_ID, FKBAR_ID)" +
                " values ('" + 
                persona.PER_NombreUno + "', '" +
                persona.PER_ApellidoUno + "', '" +
                persona.PER_NumeroDocumento + "', '" + 
                persona.PER_DireccionVinda + "', '" +
                persona.PER_Correo + "', '" +
                persona.PER_Contrasenia + "', '" +
                persona.FKROL_ID + "', '" +
                persona.FKTIPODOC_ID + "', '" +
                persona.FKBAR_ID + "')";

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public List<TipoDocumentoModel> enlistarDocumento()
        {
            connection.Open();
            string sql = "select TIPDOC_ID, TIPDOC_Nombre from tipodocumento";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoDocumentoModel> documentos = new List<TipoDocumentoModel>();
            while (reader.Read())
            {
                TipoDocumentoModel tipoDocumento = new TipoDocumentoModel();
                tipoDocumento.TIPDOC_ID = reader.GetInt32(0);
                tipoDocumento.TIPDOC_Nombre = reader.GetString(1);
                documentos.Add(tipoDocumento);
            }
            connection.Close();
            return documentos;
        }
    }
}
