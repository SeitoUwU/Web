using MySql.Data.MySqlClient;
using Web.Models;
using System.Data;

namespace Web.Datos
{
    public class UsuarioDatos
    {
        private readonly MySqlConnection connection;
        private string cookie;

        public UsuarioDatos()
        {}

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
            String sql = "select PUBLI_ID, PUBLI_Titulo,PUBLI_Descripcion, FKPER_RealizaPublicacion, FKTIPUBLI_ID" +
                " from publicacion where PUBLI_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<PublicacionModel> listaPublicaciones = new List<PublicacionModel>();
            while (reader.Read())
            {
                PublicacionModel publi = new PublicacionModel();
                publi.PUBLI_ID = reader.GetInt32(0);
                publi.PUBLI_Titulo = reader.GetString(1);
                publi.PUBLI_Descripcion = reader.GetString(2);
                publi.FKPER_RealizaPublicacion = reader.GetInt32(3);
                publi.FKTIPUBLI_ID = reader.GetInt32(4);
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
            command1.Parameters.AddWithValue("@fotoelemento", contenido.elementos.Imagen_elemento);

            command1.ExecuteNonQuery();

            connection.Close();
            return true;
        }

        public Boolean InsertarPublicacionMascota(ContenidoModel contenido)
        {
            var correoPersona = cookie;
            connection.Open();
            using (MySqlCommand command = new MySqlCommand("insertarPublicacionMascota", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@titulo", contenido.publicacion.PUBLI_Titulo);
                command.Parameters.AddWithValue("@descripcion", contenido.publicacion.PUBLI_Descripcion);
                command.Parameters.AddWithValue("@persona", ObtenerIdPersonaPorCorreo(correoPersona));
                command.Parameters.AddWithValue("@tipoPubli", contenido.publicacion.FKTIPUBLI_ID);
                command.Parameters.AddWithValue("@nombreMasc", contenido.mascota.MASC_Nombre);
                command.Parameters.AddWithValue("@edadMasc", contenido.mascota.MASC_Edad);
                command.Parameters.AddWithValue("@descripcionMasc", contenido.mascota.MASC_Descripcion);
                command.Parameters.AddWithValue("@generoMascota", contenido.mascota.FKGENMASC_ID);
                command.Parameters.AddWithValue("@caracteristicaMascota", contenido.mascota.FKCARAC_ID);
                command.Parameters.AddWithValue("@razaMascota", contenido.mascota.FKTIPRAZA_ID);
                command.Parameters.AddWithValue("@fechaCirugia", contenido.cirugia.CIRU_FechaCirugia);
                command.Parameters.AddWithValue("@tipoCirugia", contenido.cirugia.FKTIPCIRU_ID);
                command.Parameters.AddWithValue("@fechaVacuna", contenido.mascTieneVac.MASCTIENVAC_FechaAplicacion);
                command.Parameters.AddWithValue("@fkvacuna", contenido.mascTieneVac.FKVAC_ID);
                command.Parameters.AddWithValue("@tratamientoAler", contenido.MascTieneAler.MASCTIENALER_Tratamiento);
                command.Parameters.AddWithValue("@fechaInicioTratamiento", contenido.MascTieneAler.MASCTIENALER_FechaInicioTratamiento);
                command.Parameters.AddWithValue("@fechaFinTratamiento", contenido.MascTieneAler.MASCTIENALER_FechaFinTratamiento);
                command.Parameters.AddWithValue("@fkAlergiaTratamiento", contenido.MascTieneAler.FKALER_ID);
                command.Parameters.AddWithValue("@fkTipoTratamiento", contenido.MascTieneAler.FKTIPTRAT_ID);
               command.Parameters.AddWithValue("@fotomascota", contenido.mascota.Imagen_mascota);
              


                command.ExecuteNonQuery();
            }
            connection.Close();
            return true;
        }
        public int ObtenerIdPersonaPorCorreo(string correo)
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
                while (reader.Read())
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

        public List<AlergiaModel> listarAlergiasPorId(int id)
        {
            connection.Open();
            string sql = "select ALER_ID, ALER_NombreAlergia from alergia " +
                "inner join tipoalergia on TIPALER_ID = FKTIPALER_ID and FKTIPALER_ID = '" + id
                + "' where ALER_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<AlergiaModel> alergias = new List<AlergiaModel>();
            while (reader.Read())
            {
                AlergiaModel alergia = new AlergiaModel();
                alergia.ALER_ID = reader.GetInt32(0);
                alergia.ALER_NombreAlergia = reader.GetString(1);
                alergias.Add(alergia);
            }
            connection.Close();
            return alergias;
        }


    }
}
