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
            string sql = "select DEP_ID, DEP_Nombre, PAIS_Nombre from departamento " +
                "inner join pais on FKPAIS_ID = PAIS_ID where DEP_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<DepartamentoModel> departamentos = new List<DepartamentoModel>();
            while (reader.Read())
            {
                DepartamentoModel dep = new DepartamentoModel();
                dep.DEP_ID = reader.GetInt32(0);
                dep.DEP_Nombre = reader.GetString(1);
                dep.pais = reader.GetString(2);
                departamentos.Add(dep);
            }
            _connection.Close();
            return departamentos;
        }

        public Boolean insertarDepartamentos(DepartamentoModel departamento)
        {
            _connection.Open();
            string sql = "insert into departamento(DEP_ID, DEP_Nombre, FKPAIS_ID, DEP_Estado)" +
                " values ('" +
                departamento.DEP_ID + "', '" +
                departamento.DEP_Nombre + "', '" +
                departamento.FKPAIS_ID + "', '" +
                departamento.DEP_Estado + "')";
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
            string sql = "update departamento set DEP_Estado = 0 where DEP_ID = '" + departamento.DEP_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<MunicipioModel> listarmunicipios()
        {
            _connection.Open();
            string sql = "select MUN_ID, MUN_Nombre, DEP_Nombre from municipio " +
                "inner join departamento on FKDEP_ID = DEP_ID where MUN_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<MunicipioModel> municipios = new List<MunicipioModel>();
            while (reader.Read())
            {
                MunicipioModel mun = new MunicipioModel();
                mun.MUN_ID = reader.GetInt32(0);
                mun.MUN_Nombre = reader.GetString(1);
                mun.departamento = reader.GetString(2);
                municipios.Add(mun);
            }
            _connection.Close();
            return municipios;
        }

        public Boolean InsertarMunicipio(MunicipioModel municipio)
        {
            _connection.Open();
            string sql = "insert into municipio (MUN_ID, MUN_Nombre, FKDEP_ID, MUN_Estado) values ('" +
                municipio.MUN_ID + "', '" +
                municipio.MUN_Nombre + "', '" +
                municipio.FKDEP_ID + "', '" +
                municipio.MUN_Estado + "')";
            MySqlCommand command = new MySqlCommand( sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean EliminarMunicipio(MunicipioModel municipio)
        {
            _connection.Open();
            string sql = "update municipio set MUN_Estado = 0 where MUN_ID = '" + municipio.MUN_ID + "'";
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
            string sql = "select BAR_ID, BAR_Nombre, MUN_Nombre from barrio " +
                "inner join municipio on FKMUN_ID = MUN_ID where BAR_Estado = true";
            MySqlCommand command = new MySqlCommand( sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<BarrioModel> barrios = new List<BarrioModel>();
            while (reader.Read())
            {
                BarrioModel barrio = new BarrioModel();
                barrio.BAR_ID = reader.GetInt32(0);
                barrio.BAR_Nombre = reader.GetString(1);
                barrio.municipio = reader.GetString(2);
                barrios.Add(barrio);
            }
            _connection.Close();
            return barrios;
        }

        public Boolean insertarBarrio(BarrioModel barrio)
        {
            _connection.Open();
            string sql = "insert into barrio (BAR_ID, BAR_Nombre, FKMUN_ID, BAR_Estado) values ('"+
                barrio.BAR_ID + "', '" +
                barrio.BAR_Nombre + "','" +
                barrio.FKMUN_ID + "', '" + 
                barrio.BAR_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarBarrio(BarrioModel barrio)
        {
            _connection.Open();
            string sql = "update barrio set BAR_Estado = 0 where BAR_ID = '" + barrio.BAR_ID + "'";
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
            string sql = "select ROL_ID, ROL_Nombre from rol where ROL_Estado = true";
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
            string sql = "insert into rol(ROL_ID, ROL_Nombre, ROL_Estado) " +
                "values(' " + rol.ROL_ID + "', '" +
                rol.ROL_Nombre + "', '" +
                rol.ROL_Estado + "')";
            MySqlCommand command = new MySqlCommand( sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarRol(RolModel rol)
        {
            _connection.Open();
            string sql = "update rol set ROL_Estado = 0 where ROL_ID = '" + rol.ROL_ID + "'";
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
            string sql = "select MOT_ID, MOT_MotivoReporte from motivoreporte where MOT_Estado = true";
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
            string sql = "insert into motivoreporte(MOT_ID, MOT_MotivoReporte, MOT_Estado) " +
                "values('" + model.MOT_ID + "', '" +
                model.MOT_MotivoReporte + "', '" +
                model.MOT_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarMotivo(MotivoReporteModel model)
        {
            _connection.Open();
            string sql = "update motivoreporte set MOT_Estado = 0 where MOT_ID = '" + model.MOT_ID + "'";
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
            string sql = "select TIPUBLI_ID, TIPUBLI_Tipo from tipopublicacion where TIPUBLI_Estado = true";
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
            string sql = "insert into tipopublicacion(TIPUBLI_ID, TIPUBLI_Tipo, TIPUBLI_Estado) " +
                "values('" + model.TIPUBLI_ID + "', '" +
                model.TIPUBLI_Tipo + "', '" +
                model.TIPUBLI_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoPublicacion(TipoPublicacionModel model)
        {
            _connection.Open();
            string sql = "update tipopublicacion set TIPUBLI_Estado = 0 where TIPUBLI_ID = '" + model.TIPUBLI_ID + "'";
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

        public List<TipoElementoModel> listarTipoElemento()
        {
            _connection.Open();
            string sql = "select TIPELEM_ID, TIPELEM_Nombre from tipoelemento where TIPELEM_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoElementoModel> tipos = new List<TipoElementoModel>();
            while (reader.Read())
            {
                TipoElementoModel tipo = new TipoElementoModel();
                tipo.TIPELEM_ID = reader.GetInt32(0);
                tipo.TIPELEM_Nombre = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoElemento(TipoElementoModel model)
        {
            _connection.Open();
            string sql = "insert into tipoelemento(TIPELEM_ID, TIPELEM_Nombre, TIPELEM_Estado) " +
                "values('" + model.TIPELEM_ID + "', '" +
                model.TIPELEM_Nombre + "', '" +
                model.TIPELEM_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoElemento(TipoElementoModel model)
        {
            _connection.Open();
            string sql = "update tipoelemento set TIPELEM_Estado = 0 where TIPELEM_ID = '" + model.TIPELEM_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoElemento(TipoElementoModel tipo)
        {
            _connection.Open();
            string sql = "update tipoelemento set TIPELEM_Nombre = '" + tipo.TIPELEM_Nombre + "' " +
                "where TIPELEM_ID = '" + tipo.TIPELEM_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<TipoCirugiaModel> listarTipoCirugia()
        {
            _connection.Open();
            string sql = "select TIPCIRU_ID, TIPCIRU_Nombre from tipocirugia where TIPCIRU_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoCirugiaModel> tipos = new List<TipoCirugiaModel>();
            while (reader.Read())
            {
                TipoCirugiaModel tipo = new TipoCirugiaModel();
                tipo.TIPCIRU_ID = reader.GetInt32(0);
                tipo.TIPCIRU_Nombre = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoCirugia(TipoCirugiaModel model)
        {
            _connection.Open();
            string sql = "insert into tipocirugia(TIPCIRU_ID, TIPCIRU_Nombre, TIPCIRU_Estado) " +
                "values('" + model.TIPCIRU_ID + "', '" +
                model.TIPCIRU_Nombre + "', '" +
                model.TIPCIRU_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoCirugia(TipoCirugiaModel model)
        {
            _connection.Open();
            string sql = "update tipocirugia set TIPCIRU_Estado = 0 where TIPCIRU_ID = '" + model.TIPCIRU_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoCirugia(TipoCirugiaModel tipo)
        {
            _connection.Open();
            string sql = "update tipocirugia set TIPCIRU_Nombre = '" + tipo.TIPCIRU_Nombre + "' " +
                "where TIPCIRU_ID = '" + tipo.TIPCIRU_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<TipoRazaModel> listarTipoRaza()
        {
            _connection.Open();
            string sql = "select TIPRAZA_ID, TIPRAZA_Nombre, TIPMASC_Nombre from tiporaza " +
                "inner join tipomascota on FKTIPMASC_ID = TIPMASC_ID where TIPRAZA_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoRazaModel> tipos = new List<TipoRazaModel>();
            while (reader.Read())
            {
                TipoRazaModel tipo = new TipoRazaModel();
                tipo.TIPRAZA_ID = reader.GetInt32(0);
                tipo.TIPRAZA_Nombre = reader.GetString(1);
                tipo.tipoMascota = reader.GetString(2);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoRaza(TipoRazaModel model)
        {
            _connection.Open();
            string sql = "insert into tiporaza(TIPRAZA_ID, TIPRAZA_Nombre, FKTIPMASC_ID, TIPRAZA_Estado) " +
                "values('" + model.TIPRAZA_ID + "', '" +
                model.TIPRAZA_Nombre + "', '" +
                model.FKTIPMASC_ID + "', '" + 
                model.TIPRAZA_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoRaza(TipoRazaModel model)
        {
            _connection.Open();
            string sql = "update tiporaza set TIPRAZA_Estado = 0 where TIPRAZA_ID = '" + model.TIPRAZA_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoRaza(TipoRazaModel tipo)
        {
            _connection.Open();
            string sql = "update tiporaza set TIPRAZA_Nombre = '" + tipo.TIPRAZA_Nombre + "', " +
                " FKTIPMASC_ID = '" + tipo.FKTIPMASC_ID + "' where TIPRAZA_ID = '" + tipo.TIPRAZA_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<CaracteristicasModel> listarCaracteristicas()
        {
            _connection.Open();
            string sql = "select CARAC_ID, CARAC_Peso, CARAC_Comportamiento, CARAC_Alimentacion from caracteristicas " +
                "where CARAC_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<CaracteristicasModel> caracteristicas = new List<CaracteristicasModel>();
            while (reader.Read())
            {
                CaracteristicasModel caracteristica = new CaracteristicasModel();
                caracteristica.CARAC_ID = reader.GetInt32(0);
                caracteristica.CARAC_Peso = reader.GetString(1);
                caracteristica.CARAC_Comportamiento = reader.GetString(2);
                caracteristica.CARAC_Alimentacion = reader.GetString(3);
                caracteristicas.Add(caracteristica);
            }
            _connection.Close();
            return caracteristicas;
        }

        public Boolean insertarCaracteristica(CaracteristicasModel model)
        {
            _connection.Open();
            string sql = "insert into caracteristicas(CARAC_ID, CARAC_Peso, CARAC_Comportamiento, CARAC_Alimentacion, CARAC_Estado) " +
                "values('" + model.CARAC_ID + "', '" +
                model.CARAC_Peso + "', '" +
                model.CARAC_Comportamiento + "', '" +
                model.CARAC_Alimentacion + "', '" + 
                model.CARAC_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarCaracteristica(CaracteristicasModel model)
        {
            _connection.Open();
            string sql = "update caracteristicas set CARAC_Estado = 0 where CARAC_ID = '" + model.CARAC_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarCaracteristica(CaracteristicasModel caracteristica)
        {
            _connection.Open();
            string sql = "update caracteristicas set CARAC_Peso = '" + caracteristica.CARAC_Peso + "', " +
                " CARAC_Comportamiento = '" + caracteristica.CARAC_Comportamiento + "', " +
                " CARAC_Alimentacion = '" + caracteristica.CARAC_Alimentacion + "' " +
                " where CARAC_ID = '" + caracteristica.CARAC_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<TipoGrupoModel> listarTipoGrupo()
        {
            _connection.Open();
            string sql = "select TIPGRUP_ID, TIPGRUP_Nombre from tipogrupo" +
                " where TIPGRUP_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoGrupoModel> tipos = new List<TipoGrupoModel>();
            while (reader.Read())
            {
                TipoGrupoModel tipo = new TipoGrupoModel();
                tipo.TIPGRUP_ID = reader.GetInt32(0);
                tipo.TIPGRUP_Nombre = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoGrupo(TipoGrupoModel model)
        {
            _connection.Open();
            string sql = "insert into tipogrupo(TIPGRUP_ID, TIPGRUP_Nombre, TIPGRUP_Estado) " +
                "values('" + model.TIPGRUP_ID + "', '" +
                model.TIPGRUP_Nombre + "', '" +
                model.TIPGRUP_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoGrupo(TipoGrupoModel model)
        {
            _connection.Open();
            string sql = "update tipogrupo set TIGRUP_Estado = 0 where TIPGRUP_ID = '" + model.TIPGRUP_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoGrupo(TipoGrupoModel tipo)
        {
            _connection.Open();
            string sql = "update tipogrupo set TIPGRUP_Nombre = '" + tipo.TIPGRUP_Nombre + "' " +
                " where TIPGRUP_ID = '" + tipo.TIPGRUP_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<TipoDocumentoModel> listarTipoDocumento ()
        {
            _connection.Open();
            string sql = "select TIPDOC_ID, TIPDOC_Nombre from tipodocumento " +
                "where TIPDOC_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoDocumentoModel> tipos = new List<TipoDocumentoModel>();
            while (reader.Read())
            {
                TipoDocumentoModel tipo = new TipoDocumentoModel();
                tipo.TIPDOC_ID = reader.GetInt32(0);
                tipo.TIPDOC_Nombre = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoDocumento(TipoDocumentoModel model)
        {
            _connection.Open();
            string sql = "insert into tipodocumento(TIPDOC_ID, TIPDOC_Nombre, TIPDOC_Estado) " +
                "values('" + model.TIPDOC_ID + "', '" +
                model.TIPDOC_Nombre + "', '" + 
                model.TIPDOC_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoDocumento(TipoDocumentoModel model)
        {
            _connection.Open();
            string sql = "update tipodocumento set TIPDOC_Estado = 0 where TIPDOC_ID = '" + model.TIPDOC_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoDocumento(TipoDocumentoModel tipo)
        {
            _connection.Open();
            string sql = "update tipodocumento set TIPDOC_Nombre = '" + tipo.TIPDOC_Nombre + "' " +
                " where TIPDOC_ID = '" + tipo.TIPDOC_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<TipoViviendaModel> listarTipoVivienda()
        {
            _connection.Open();
            string sql = "select TIPVIVI_ID, TIPVIVI_Vivienda from tipovivienda " +
                "where TIPVIVI_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoViviendaModel> tipos = new List<TipoViviendaModel>();
            while (reader.Read())
            {
                TipoViviendaModel tipo = new TipoViviendaModel();
                tipo.TIPVIVI_ID = reader.GetInt32(0);
                tipo.TIPVIVI_Vivienda = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoVivienda(TipoViviendaModel model)
        {
            _connection.Open();
            string sql = "insert into tipovivienda(TIPVIVI_ID, TIPVIVI_Vivienda, TIPVIVI_Estado) " +
                "values('" + model.TIPVIVI_ID + "', '" +
                model.TIPVIVI_Vivienda + "', '" + 
                model.TIPVIVI_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoVivienda(TipoViviendaModel model)
        {
            _connection.Open();
            string sql = "update tipovivienda set TIPVIVI_Estado = 0 where TIPVIVI_ID = '" + model.TIPVIVI_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoVivienda(TipoViviendaModel tipo)
        {
            _connection.Open();
            string sql = "update tipovivienda set TIPVIVI_Vivienda = '" + tipo.TIPVIVI_Vivienda + "' " +
                " where TIPVIVI_ID = '" + tipo.TIPVIVI_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<TipoTratamientoModel> listarTipoTratamiento()
        {
            _connection.Open();
            string sql = "select TIPTRAT_ID, TIPTRAT_Nombre from tipotratamiento " +
                "where TIPTRAT_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoTratamientoModel> tipos = new List<TipoTratamientoModel>();
            while (reader.Read())
            {
                TipoTratamientoModel tipo = new TipoTratamientoModel();
                tipo.TIPTRAT_ID = reader.GetInt32(0);
                tipo.TIPTRAT_Nombre = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoTratamiento(TipoTratamientoModel model)
        {
            _connection.Open();
            string sql = "insert into tipotratamiento(TIPTRAT_ID, TIPTRAT_Nombre, TIPTRAT_Estado) " +
                "values('" + model.TIPTRAT_ID + "', '" +
                model.TIPTRAT_Nombre + "', '" + 
                model.TIPTRAT_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoTratamiento(TipoTratamientoModel model)
        {
            _connection.Open();
            string sql = "update tipotratamiento set TIPTRAT_Estado = 0 where TIPTRAT_ID = '" + model.TIPTRAT_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoTratamiento(TipoTratamientoModel tipo)
        {
            _connection.Open();
            string sql = "update tipotratamiento set TIPTRAT_Nombre = '" + tipo.TIPTRAT_Nombre + "' " +
                " where TIPTRAT_ID = '" + tipo.TIPTRAT_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<TipoAlergiaModel> listarTipoAlergia()
        {
            _connection.Open();
            string sql = "select TIPALER_ID, TIPALER_Nombre from tipoalergia " +
                "where TIPALER_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoAlergiaModel> tipos = new List<TipoAlergiaModel>();
            while (reader.Read())
            {
                TipoAlergiaModel tipo = new TipoAlergiaModel();
                tipo.TIPALER_ID = reader.GetInt32(0);
                tipo.TIPALER_Nombre = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoAlergia(TipoAlergiaModel model)
        {
            _connection.Open();
            string sql = "insert into tipoalergia(TIPALER_ID, TIPALER_Nombre, TIPALER_Estado) " +
                "values('" + model.TIPALER_ID + "', '" +
                model.TIPALER_Nombre + "', '" +
                model.TIPALER_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoAlergia(TipoAlergiaModel model)
        {
            _connection.Open();
            string sql = "update tipoalergia set TIPALER_Estado = 0 where TIPALER_ID = '" + model.TIPALER_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoAlergia(TipoAlergiaModel tipo)
        {
            _connection.Open();
            string sql = "update tipoalergia set TIPALER_Nombre = '" + tipo.TIPALER_Nombre + "' " +
                " where TIPALER_ID = '" + tipo.TIPALER_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }


        public List<TipoMascotaModel> listarTipoMascota()
        {
            _connection.Open();
            string sql = "select TIPMASC_ID, TIPMASC_Nombre from tipomascota " +
                "where TIPMASC_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoMascotaModel> tipos = new List<TipoMascotaModel>();
            while (reader.Read())
            {
                TipoMascotaModel tipo = new TipoMascotaModel();
                tipo.TIPMASC_ID = reader.GetInt32(0);
                tipo.TIPMASC_Nombre = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoMascota(TipoMascotaModel model)
        {
            _connection.Open();
            string sql = "insert into tipomascota(TIPMASC_ID, TIPMAC_Nombre, TIPMASC_Estado) " +
                "values('" + model.TIPMASC_ID + "', '" +
                model.TIPMASC_Nombre + "', '" +
                model.TIPMASC_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoMascota(TipoMascotaModel model)
        {
            _connection.Open();
            string sql = "update tipomascota set TIPMASC_Estado = 0 where TIPMASC_ID = '" + model.TIPMASC_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoMascota(TipoMascotaModel tipo)
        {
            _connection.Open();
            string sql = "update tipomascota set TIPMAC_Nombre = '" + tipo.TIPMASC_Nombre + "' " +
                " where TIPMASC_ID = '" + tipo.TIPMASC_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<TipoVacunaModel> listarTipoVacuna()
        {
            _connection.Open();
            string sql = "select TIPVAC_ID, TIPVAC_Nombre from tipovacuna where" +
                " TIPVAC_Estado = true";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoVacunaModel> tipos = new List<TipoVacunaModel>();
            while (reader.Read())
            {
                TipoVacunaModel tipo = new TipoVacunaModel();
                tipo.TIPVAC_ID = reader.GetInt32(0);
                tipo.TIPVAC_Nombre = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoVacuna(TipoVacunaModel model)
        {
            _connection.Open();
            string sql = "insert into tipovacuna(TIPVAC_ID, TIPVAC_Nombre, TIPVAC_Estado) " +
                "values('" + model.TIPVAC_ID + "', '" +
                model.TIPVAC_Nombre + "', '" +
                model.TIPVAC_Estado + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoVacuna(TipoVacunaModel model)
        {
            _connection.Open();
            string sql = "update tipovacuna set TIPVAC_Estado = 0 where TIPVAC_ID = '" + model.TIPVAC_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean actualizarTipoVacuna(TipoVacunaModel tipo)
        {
            _connection.Open();
            string sql = "update tipovacuna set TIPVAC_Nombre = '" + tipo.TIPVAC_Nombre + "' " +
                " where TIPVAC_ID = '" + tipo.TIPVAC_ID + "'";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public List<PublicacionModel> listarPublicaciones()
        {
            _connection.Open();
            String sql = "select PUBLI_Titulo,PUBLI_Descripcion from publicacion";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<PublicacionModel> listaPublicaciones = new List<PublicacionModel>();
            while (reader.Read())
            {
                PublicacionModel publi = new PublicacionModel();
                publi.PUBLI_Titulo = reader.GetString(0);
                publi.PUBLI_Descripcion = reader.GetString(1);
                listaPublicaciones.Add(publi);
            }
            _connection.Close();
            return listaPublicaciones;

        }
    }
}
