using MySql.Data.MySqlClient;
using Web.Models;

namespace Web.Datos
{
    public class RegistroMascotaDatos
    {
        public readonly MySqlConnection Connection;
        
        public RegistroMascotaDatos(MySqlConnection mySql)
        {
            Connection = mySql;
        }

        public List<CaracteristicasModel> caracteristicas()
        {
            Connection.Open();
            string sql = "Select CARAC_ID, " +
                "CARAC_Peso, " +
                "CARAC_Comportamiento, " +
                "CARAC_Alimentacion " +
                "from caracteristicas";
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<CaracteristicasModel> caracteristicas = new List<CaracteristicasModel>();
            while (reader.Read())
            {
                CaracteristicasModel caracteristicasModel = new CaracteristicasModel();
                caracteristicasModel.CARAC_ID = reader.GetInt32(0);
                caracteristicasModel.CARAC_Peso = reader.GetString(1);
                caracteristicasModel.CARAC_Comportamiento = reader.GetString(2);
                caracteristicasModel.CARAC_Alimentacion = reader.GetString(3);
                caracteristicasModel.Carac_caracteristicas = $"{reader.GetString(1)}, {reader.GetString(2)}, {reader.GetString(3)}";
                caracteristicas.Add(caracteristicasModel);
            }
            Connection.Close();
            return caracteristicas;
        }
        
        //Metodo para enlistar los tipos de mascota
        public List<TipoMascotaModel> TipoMascota() 
        {
            //Abre la conexion
            Connection.Open();
            //Consulta a la base de datos
            string sql = "SELECT TIPMASC_ID," +
                " TIPMAC_Nombre FROM tipomascota";
            //Ejecuta la consulta
            MySqlCommand command = new MySqlCommand(sql, Connection);
            //Lee la consulta
            MySqlDataReader reader = command.ExecuteReader();
            //Crea una lista de tipo TipoMascotaModel
            List<TipoMascotaModel> tipoMascota = new List<TipoMascotaModel>();
            //Recorre la lista
            while (reader.Read())
            {
                //Crea un objeto de tipo TipoMascotaModel
                TipoMascotaModel tipoMascotaModel = new TipoMascotaModel();
                //Asigna los valores a los atributos del objeto
                tipoMascotaModel.TIPMASC_ID= reader.GetInt32(0);
                tipoMascotaModel.TIPMASC_Nombre = reader.GetString(1);
                //Agrega el objeto a la lista
                tipoMascota.Add(tipoMascotaModel);
            }
            //Cierra la conexion
            Connection.Close();
            //Retorna la lista
            return tipoMascota;
        }

        public List<TipoRazaModel> tipoRazas()
        {
            Connection.Open();
            string sql = "select TIPRAZA_ID, TIPRAZA_Nombre from tiporaza";
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoRazaModel> tipoRaza = new List<TipoRazaModel>();
            while (reader.Read())
            {
                TipoRazaModel tipoRazaModel = new TipoRazaModel();
                tipoRazaModel.TIPRAZA_ID = reader.GetInt32(0);
                tipoRazaModel.TIPRAZA_Nombre = reader.GetString(1);
                tipoRaza.Add(tipoRazaModel);
            }
            Connection.Close();
            return tipoRaza;
        }

        public List<GeneroMascotaModel> generoMascotas()
        {
            Connection.Open();
            string sql = "select GENMASC_ID, GENMASC_Nombre from generomascota";
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<GeneroMascotaModel> generoMascotas = new List<GeneroMascotaModel>();
            while (reader.Read())
            {
                GeneroMascotaModel generoMascota = new GeneroMascotaModel();
                generoMascota.GENMASC_ID = reader.GetInt32(0);
                generoMascota.GENMASC_Nombre = reader.GetString(1);
                generoMascotas.Add(generoMascota);
            }
            Connection.Close();
            return generoMascotas;
        }

        //Metodo para registrar una mascota
        public Boolean RegistrarMascota(MascotaModel mascota)
        {
            //Abre la conexion
            Connection.Open();
            //Consulta a la base de datos
            string sql = "INSERT INTO mascota (MASC_Nombre, MASC_Edad, MASC_Descripcion, FKGENMASC_ID, FKPUBLI_ID, FKCARAC_ID, FKTIPRAZA_ID)" +
                " VALUES ('" + mascota.MASC_Nombre + "', '" + mascota.MASC_Edad + "', '" + mascota.MASC_Descripcion + "', '" + mascota.FKGENMASC_ID + "', '" + mascota.FKPUBLI_ID + "', '" + mascota.FKCARAC_ID + "', '" + mascota.FKTIPRAZA_ID + "')";
            //Ejecuta la consulta
            MySqlCommand command = new MySqlCommand(sql, Connection);
            //Ejecuta el query
            command.ExecuteNonQuery();
            //Cierra la conexion
            Connection.Close();
            return false;
        }

        public Boolean EditarMascota(MascotaModel mascota)
        {
            Connection.Open();
            string sql = "UPDATE mascota SET " +
                "MASC_Nombre = '" + mascota.MASC_Nombre + "', " +
                "MASC_Edad = '" + mascota.MASC_Edad + "', " +
                "MASC_Descripcion = '" + mascota.MASC_Descripcion + "', " +
                "FKGENMASC_ID = '" + mascota.FKGENMASC_ID + "', " +
                "FKPUBLI_ID = '" + mascota.FKPUBLI_ID + "', " +
                "FKCARAC_ID = '" + mascota.FKCARAC_ID + "', " +
                "FKTIPRAZA_ID = '" + mascota.FKTIPRAZA_ID + "' " +
                "WHERE MASC_ID = '" + mascota.MASC_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
            return false;
        }

    }
}
