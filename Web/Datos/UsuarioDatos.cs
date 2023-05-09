using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System.ComponentModel;
using System.Configuration;
using Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Web.Datos
{
    public class UsuarioDatos
    {
        private readonly MySqlConnection connection;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UsuarioDatos(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public UsuarioDatos(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
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

        public List<TipoPublicacionModel> listarTipoPublicacion()
        {
            connection.Open();
            string sql = "select TIPUBLI_ID, TIPUBLI_Tipo from tipopublicacion" +
                " where TIPUBLI_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoPublicacionModel> tipoPublicaciones = new List<TipoPublicacionModel>();
            while (reader.Read())
            {
                TipoPublicacionModel tipoPublicacion = new TipoPublicacionModel();
                tipoPublicacion.TIPUBLI_ID = reader.GetInt32(0);
                tipoPublicacion.TIPUBLI_Tipo = reader.GetString(1);
                tipoPublicaciones.Add(tipoPublicacion);
            }
            connection.Close();
            return tipoPublicaciones;
        }

        public List<TipoElementoModel> listarTipoElementos()
        {
            connection.Open();
            string sql = "select TIPELEM_ID, TIPELEM_Nombre from tipoelemento " +
                "where TIPELEM_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoElementoModel> tipoElementos = new List<TipoElementoModel>();
            while (reader.Read())
            {
                TipoElementoModel tipoElemento = new TipoElementoModel();
                tipoElemento.TIPELEM_ID = reader.GetInt32(0);
                tipoElemento.TIPELEM_Nombre = reader.GetString(1);
                tipoElementos.Add(tipoElemento);
            }
            connection.Close();
            return tipoElementos;
        }

        public Boolean InsertarPublicacionArticulo(ContenidoModel contenido)
        {

            connection.Open();

            using (MySqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    string sql = "INSERT INTO publicacion " +
                                 "(PUBLI_Titulo, PUBLI_Descripcion, PUBLI_Estado, FKPER_RealizaPublicacion, FKTIPUBLI_ID, FKFOR_ID, PUBLI_TOTAL, PUBLI_Cantidad) " +
                                 "VALUES " +
                                 "(@titulo, @descripcion, @estado, @fkper, @fktipoubli, @fkfor, @total, @cantidad)";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Transaction = transaction;

                    command.Parameters.AddWithValue("@titulo", contenido.publicacion.PUBLI_Titulo);
                    command.Parameters.AddWithValue("@descripcion", contenido.publicacion.PUBLI_Descripcion);
                    command.Parameters.AddWithValue("@estado", contenido.publicacion.PUBLI_Estado);
                    command.Parameters.AddWithValue("@fkper", ObtenerIdPersonaPorCorreo(httpContextAccessor.HttpContext.Request.Cookies["CorreoPersona"]));
                    command.Parameters.AddWithValue("@fktipoubli", contenido.publicacion.FKTIPUBLI_ID);
                    command.Parameters.AddWithValue("@fkfor", contenido.publicacion.FKFOR_ID);
                    command.Parameters.AddWithValue("@total", contenido.publicacion.PUBLI_Total);
                    command.Parameters.AddWithValue("@cantidad", contenido.publicacion.PUBLI_Cantidad);

                    command.ExecuteNonQuery();

                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Manejar la excepción
                    return false;
                }


            }
        }
        private int ObtenerIdPersonaPorCorreo(string correo)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            using (MySqlConnection connection = new MySqlConnection(configuration.GetConnectionString("ConexionMySql")))
            {
                connection.Open();
                string sql = "SELECT PER_ID FROM persona WHERE PER_Correo = @correo";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@correo", correo);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    // Manejar el caso en que no se encuentra el correo
                    return -1;
                }
            }
        }
    }
}
