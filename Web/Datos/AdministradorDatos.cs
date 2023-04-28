using Microsoft.AspNetCore.Mvc;
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

        public Boolean ActualizarPais(PaisModel pais)
        {
            _connection.Open();
            string sql =  "update pais set PAIS_Nombre = '" + pais.PAIS_Nombre + "' " +
                "where PAIS_ID = '" + pais.PAIS_ID +"'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean EliminarPais(PaisModel pais)
        {
            _connection.Open();
            string sql = "delete from pais where PAIS_ID = '" + pais.PAIS_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<DepartamentoModel> listarDepartamentos()
        {
            _connection.Open();
            string sql = "select DEP_ID, DEP_Nombre from departamento";
            MySqlCommand command = new MySqlCommand( sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<DepartamentoModel> departamentos = new List<DepartamentoModel>();
            DepartamentoModel dep = new DepartamentoModel();
            while (reader.Read())
            {
                dep.DEP_ID = reader.GetInt32(0);
                dep.DEP_Nombre = reader.GetString(1);
                departamentos.Add(dep);
            }
            _connection.Close();
            return departamentos;
        }

        public ActionResult insertarDepartamentos(int idDepartamento, string nombreDepartamento, int fkpais)
        {
            _connection.Open();
            DepartamentoModel departamento = new DepartamentoModel();
            departamento.DEP_ID = idDepartamento;
            departamento.DEP_Nombre = nombreDepartamento;
            departamento.FKPAIS_ID = fkpais;
            string sql = "insert into departamento(DEP_ID, DEP_Nombre, FKPAIS_ID)" +
                " values ('" +
                departamento.DEP_ID + "', ";
            return null;
        }

        public List<MunicipioModel> listarmunicipios()
        {
            _connection.Open();
            string sql = "select MUN_ID, MUN_Nombre from municipio";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<MunicipioModel> municipios = new List<MunicipioModel>();
            while (reader.Read())
            {
                MunicipioModel mun = new MunicipioModel();
                mun.MUN_ID = reader.GetInt32(0);
                mun.MUN_Nombre = reader.GetString(1);
                municipios.Add(mun);
            }
            _connection.Close();
            return municipios;
        }
    }
}
