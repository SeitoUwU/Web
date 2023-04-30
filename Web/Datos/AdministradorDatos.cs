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
            string sql = "update pais set PAIS_Nombre = '" + pais.PAIS_Nombre + "' " +
                "where PAIS_ID = '" + pais.PAIS_ID + "'";
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
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<DepartamentoModel> departamentos = new List<DepartamentoModel>();
            while (reader.Read())
            {
                DepartamentoModel dep = new DepartamentoModel();
                dep.DEP_ID = reader.GetInt32(0);
                dep.DEP_Nombre = reader.GetString(1);
                departamentos.Add(dep);
            }
            _connection.Close();
            return departamentos;
        }

        public Boolean insertarDepartamentos(DepartamentoModel departamento)
        {
            _connection.Open();
            string sql = "insert into departamento(DEP_ID, DEP_Nombre, FKPAIS_ID)" +
                " values ('" +
                departamento.DEP_ID + "', '" +
                departamento.DEP_Nombre + "', '" +
                departamento.FKPAIS_ID + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean ActualizarDepartamento(DepartamentoModel departamento)
        {
            _connection.Open();
            string sql = "update departamento set DEP_Nombre = '" + departamento.DEP_Nombre + "', "
                + " FKPAIS_ID = '" + departamento.FKPAIS_ID + "' " +
                "where DEP_ID = '" + departamento.DEP_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        } 

        public Boolean EliminarDepartamento(DepartamentoModel departamento)
        {
            _connection.Open();
            string sql = "delete from departamento where DEP_ID = '" + departamento.DEP_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
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

        public Boolean InsertarMunicipio(MunicipioModel municipio)
        {
            _connection.Open();
            string sql = "insert into municipio (MUN_ID, MUN_Nombre, FKDEP_ID) values ('" +
                municipio.MUN_ID + "', '" +
                municipio.MUN_Nombre + "', '" +
                municipio.FKDEP_ID + "')";
            MySqlCommand command = new MySqlCommand( sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean EliminarMunicipio(MunicipioModel municipio)
        {
            _connection.Open();
            string sql = "delete from municipio where MUN_ID = '" + municipio.MUN_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean ActualizarMunicipio (MunicipioModel municipio)
        {
            _connection.Open();
            string sql = "update municipio set MUN_Nombre = '" + municipio.MUN_Nombre +
                "', FKDEP_ID = '" + municipio.FKDEP_ID + "' where MUN_ID = '" + municipio.MUN_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<BarrioModel> listarBarrios()
        {
            _connection.Open();
            string sql = "select BAR_ID, BAR_Nombre from barrio";
            MySqlCommand command = new MySqlCommand( sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<BarrioModel> barrios = new List<BarrioModel>();
            while (reader.Read())
            {
                BarrioModel barrio = new BarrioModel();
                barrio.BAR_ID = reader.GetInt32(0);
                barrio.BAR_Nombre = reader.GetString(1);
                barrios.Add(barrio);
            }
            _connection.Close();
            return barrios;
        }

        public Boolean insertarBarrio(BarrioModel barrio)
        {
            _connection.Open();
            string sql = "insert into barrio (BAR_ID, BAR_Nombre, FKMUN_ID) values ('"+
                barrio.BAR_ID + "', '" +
                barrio.BAR_Nombre + "','" +
                barrio.FKMUN_ID + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarBarrio(BarrioModel barrio)
        {
            _connection.Open();
            string sql = "delete from barrio where BAR_ID = '" + barrio.BAR_ID + "'";
            MySqlCommand command = new MySqlCommand( sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean ActualizarBarrio(BarrioModel barrio)
        {
            _connection.Open();
            string sql = "update barrio set BAR_Nombre = '" + barrio.BAR_Nombre + "', " +
                "FKMUN_ID = '" + barrio.FKMUN_ID + "' where BAR_ID = '" + barrio.BAR_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<RolModel> listarRoles()
        {
            _connection.Open();
            string sql = "select ROL_ID, ROL_Nombre from rol";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<RolModel> roles = new List<RolModel>();
            while (reader.Read())
            {
                RolModel rol = new RolModel();
                rol.ROL_ID = reader.GetInt32(0);
                rol.ROL_Nombre = reader.GetString(1);
                roles.Add(rol);
            }
            _connection.Close();
            return roles;
        }

        public Boolean insertarRol(RolModel rol)
        {
            _connection.Open();
            string sql = "insert into rol(ROL_ID, ROL_Nombre) " +
                "values(' " + rol.ROL_ID + "', '" +
                rol.ROL_Nombre + "')";
            MySqlCommand command = new MySqlCommand( sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarRol(RolModel rol)
        {
            _connection.Open();
            string sql = "delete from rol where ROL_ID = '" + rol.ROL_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarRol(RolModel rol)
        {
            _connection.Open();
            string sql = "update rol set ROL_Nombre = '" + rol.ROL_Nombre +"' " +
                "where ROL_ID = '" + rol.ROL_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<MotivoReporteModel> listarMotivoReporte()
        {
            _connection.Open();
            string sql = "select MOT_ID, MOT_MotivoReporte from motivoreporte";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<MotivoReporteModel> motivos = new List<MotivoReporteModel>();
            while (reader.Read())
            {
                MotivoReporteModel motivo = new MotivoReporteModel();
                motivo.MOT_ID = reader.GetInt32(0);
                motivo.MOT_MotivoReporte = reader.GetString(1);
                motivos.Add(motivo);
            }
            _connection.Close();
            return motivos;
        }

        public Boolean insertarMotivo(MotivoReporteModel model)
        {
            _connection.Open();
            string sql = "insert into motivoreporte(MOT_ID, MOT_MotivoReporte) " +
                "values('" + model.MOT_ID + "', '" +
                model.MOT_MotivoReporte + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarMotivo(MotivoReporteModel model)
        {
            _connection.Open();
            string sql = "delete from motivoreporte where MOT_ID = '" + model.MOT_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarMotivo(MotivoReporteModel motivo)
        {
            _connection.Open();
            string sql = "update motivoreporte set MOT_MotivoReporte = '" + motivo.MOT_MotivoReporte +"' " +
                "where MOT_ID = '" + motivo.MOT_ID + "'";
            MySqlCommand command = new MySqlCommand( sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<TipoPublicacionModel> listarTipoPublicacion()
        {
            _connection.Open();
            string sql = "select TIPUBLI_ID, TIPUBLI_Tipo from tipopublicacion";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoPublicacionModel> tipos = new List<TipoPublicacionModel>();
            while (reader.Read())
            {
                TipoPublicacionModel tipo = new TipoPublicacionModel();
                tipo.TIPUBLI_ID = reader.GetInt32(0);
                tipo.TIPUBLI_Tipo = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoPublicacion(TipoPublicacionModel model)
        {
            _connection.Open();
            string sql = "insert into tipopublicacion(TIPUBLI_ID, TIPUBLI_Tipo) " +
                "values('" + model.TIPUBLI_ID + "', '" +
                model.TIPUBLI_Tipo + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoPublicacion(TipoPublicacionModel model)
        {
            _connection.Open();
            string sql = "delete from tipopublicacion where TIPUBLI_ID = '" + model.TIPUBLI_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoPublicacion(TipoPublicacionModel tipo)
        {
            _connection.Open();
            string sql = "update tipopublicacion set TIPUBLI_Tipo = '" + tipo.TIPUBLI_Tipo + "' " +
                "where TIPUBLI_ID = '" + tipo.TIPUBLI_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
    }
}
