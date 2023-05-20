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

        public Boolean insertarFormulario(FormularioModel formulario, int idPersona,int idPublicacion)
        {
            int idMascota = buscarMascotaPorIdPublicacion(idPublicacion);
            connection.Open();
            using (MySqlCommand command = new MySqlCommand("insertarFormulario", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@contacto", formulario.FOR_Contacto);
                command.Parameters.AddWithValue("@motivoAdopcion", formulario.FOR_MotivoAdopcion);
                command.Parameters.AddWithValue("@cantidadPersonas", formulario.FOR_CantidadPersonasVivienda);
                command.Parameters.AddWithValue("@casa", formulario.FOR_CasaSegura);
                command.Parameters.AddWithValue("@alergiaCasa", formulario.FOR_AlergiaEnCasa);
                command.Parameters.AddWithValue("@ubicacion", formulario.FOR_UbicacionCasa);
                command.Parameters.AddWithValue("@enfermedades", formulario.FOR_EnfermedadesRespiratoriasEnCasa);
                command.Parameters.AddWithValue("@fkpersona", idPersona);
                command.Parameters.AddWithValue("@fkmascota", idMascota);
                command.Parameters.AddWithValue("@fktipovivienda", formulario.FKTIPVIVI_ID);
                command.Parameters.AddWithValue("@fkpublicacion", idPublicacion);

                command.ExecuteNonQuery();

            }
            connection.Close();
            return false;
        }

        public int buscarMascotaPorIdPublicacion(int idMascota)
        {
            connection.Open();
            string sql = "SELECT MASC_ID FROM mascota WHERE FKPUBLI_ID = @idMascota";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@idMascota", idMascota);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                idMascota = reader.GetInt32(0);
            }
            connection.Close();
            return idMascota;
        }
    }
}
