using MySql.Data.MySqlClient;
using System.ComponentModel;
using Web.Models;

namespace Web.Datos
{
    public class UsuarioDatos
    {
        private readonly MySqlConnection connection;

        public UsuarioDatos(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public PersonaModel listarDatosUsuario(PersonaModel persona)
        {
            connection.Open();
            string sql = "select  ifnull(PER_Usuario, 'Sin usuario') as Usuario, " +
                "PER_NombreUno, " +
                "PER_ApellidoUno, " +
                "PER_DireccionVivienda, " +
                "PER_Correo, " +
                "(select count(FKPER_RealizaPublicacion) " +
                "from publicacion " +
                "inner join persona on FKPER_RealizaPublicacion = PER_ID) as Cantidad_Publicacion " +
                "from persona where PER_Correo = '" + persona.PER_Correo + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                persona.PER_Usuario = reader.GetString("Usuario");
                persona.PER_NombreUno = reader.GetString("PER_NombreUno");
                persona.PER_ApellidoUno = reader.GetString("PER_ApellidoUno");
                persona.PER_DireccionVinda = reader.GetString("PER_DireccionVivienda");
                persona.PER_Correo = reader.GetString("PER_Correo");
                persona.CantidadPublicacion = reader.GetInt32("Cantidad_Publicacion");
            }
            connection.Close();
            return persona;
        }
    }
}
