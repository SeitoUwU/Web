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
        private string cookie;

        public UsuarioDatos(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public UsuarioDatos(String cookie, MySqlConnection connection)
        {
            this.connection = connection;
            this.cookie = cookie;
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

        public List<PublicacionModel> listarPublicaciones()
        {
            connection.Open();
            String sql = "select PUBLI_Titulo,PUBLI_Descripcion from publicacion where PUBLI_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<PublicacionModel> listaPublicaciones = new List<PublicacionModel>();
            while (reader.Read())
            {
                PublicacionModel publi = new PublicacionModel();
                publi.PUBLI_Titulo = reader.GetString(0);
                publi.PUBLI_Descripcion = reader.GetString(1);
                listaPublicaciones.Add(publi);
            }
            connection.Close();
            return listaPublicaciones;

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
            var correoPersona = cookie;
            connection.Open();
            string sql = "INSERT INTO publicacion " +
                         "(PUBLI_Titulo, PUBLI_Descripcion, FKPER_RealizaPublicacion, FKTIPUBLI_ID) " +
                         "VALUES " +
                         "(@titulo, @descripcion, @fkper, @fktipoubli)";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@titulo", contenido.publicacion.PUBLI_Titulo);
            command.Parameters.AddWithValue("@descripcion", contenido.publicacion.PUBLI_Descripcion);
            command.Parameters.AddWithValue("@fkper", ObtenerIdPersonaPorCorreo(correoPersona));
            command.Parameters.AddWithValue("@fktipoubli", contenido.publicacion.FKTIPUBLI_ID);

            command.ExecuteNonQuery();

            sql = "insert into elementos (ELEM_Nombre, ELEM_Descripcion, ELEM_Valor, FKTIPELEM_ID) " +
                "values (@nombre, @descripcion, @valor, @tipoElemento)";

            MySqlCommand command1 = new MySqlCommand(sql, connection);

            command1.Parameters.AddWithValue("@nombre", contenido.elementos.ELEM_Nombre);
            command1.Parameters.AddWithValue("@descripcion", contenido.elementos.ELEM_Descripcion);
            command1.Parameters.AddWithValue("@valor", contenido.elementos.ELEM_Valor);
            command1.Parameters.AddWithValue("@tipoElemento", contenido.elementos.FKTIPELEM_ID);

            command1.ExecuteNonQuery();

            connection.Close();
            return true;
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

                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while(reader.Read())
                {
                    id = (int)reader.GetUInt32(0);
                }

                connection.Close();
                return id;
            }
        }

        public List<TipoRazaModel> listarTipoRazaPorId(int id)
        {
            connection.Open();
            string sql = "select TIPRAZA_ID, TIPRAZA_Nombre from tiporaza " +
                "inner join tipomascota on  TIPMASC_ID = FKTIPMASC_ID and FKTIPMASC_ID = '" + id + "' " +
                "where TIPRAZA_estado = true";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoRazaModel> tipoRazas = new List<TipoRazaModel>();
            while (reader.Read())
            {
                TipoRazaModel tipoRaza = new TipoRazaModel();
                tipoRaza.TIPRAZA_ID = reader.GetInt32(0);
                tipoRaza.TIPRAZA_Nombre = reader.GetString(1);
                tipoRazas.Add(tipoRaza);
            }
            connection.Close();
            return tipoRazas;
        }

        public List<VacunaModel> listarVacunasPorId(int id)
        {
            connection.Open();
            string sql = "select VAC_ID, VAC_Nombre from vacuna " +
                "inner join tipovacuna on TIPVAC_ID = FKTIPVAC_ID and FKTIPVAC_ID = '" + id
                + "' where VAC_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<VacunaModel> vacunas = new List<VacunaModel>();
            while (reader.Read())
            {
                VacunaModel vacuna = new VacunaModel();
                vacuna.VAC_ID = reader.GetInt32(0);
                vacuna.VAC_Nombre = reader.GetString(1);
                vacunas.Add(vacuna);
            }
            connection.Close();
            return vacunas;
        }
    }
}
