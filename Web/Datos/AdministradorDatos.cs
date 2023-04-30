﻿using Microsoft.AspNetCore.Mvc;
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

        public List<TipoElementoModel> listarTipoElemento()
        {
            _connection.Open();
            string sql = "select TIPELEM_ID, TIPELEM_Nombre from tipoelemento";
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
            string sql = "insert into tipoelemento(TIPELEM_ID, TIPELEM_Nombre) " +
                "values('" + model.TIPELEM_ID + "', '" +
                model.TIPELEM_Nombre + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoElemento(TipoElementoModel model)
        {
            _connection.Open();
            string sql = "delete from tipoelemento where TIPELEM_ID = '" + model.TIPELEM_ID + "'";
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
            string sql = "select TIPCIRU_ID, TIPCIRU_Nombre from tipocirugia";
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
            string sql = "insert into tipocirugia(TIPCIRU_ID, TIPCIRU_Nombre) " +
                "values('" + model.TIPCIRU_ID + "', '" +
                model.TIPCIRU_Nombre + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoCirugia(TipoCirugiaModel model)
        {
            _connection.Open();
            string sql = "delete from tipocirugia where TIPCIRU_ID = '" + model.TIPCIRU_ID + "'";
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
            string sql = "select TIPRAZA_ID, TIPRAZA_Nombre from tiporaza";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<TipoRazaModel> tipos = new List<TipoRazaModel>();
            while (reader.Read())
            {
                TipoRazaModel tipo = new TipoRazaModel();
                tipo.TIPRAZA_ID = reader.GetInt32(0);
                tipo.TIPRAZA_Nombre = reader.GetString(1);
                tipos.Add(tipo);
            }
            _connection.Close();
            return tipos;
        }

        public Boolean insertarTipoRaza(TipoRazaModel model)
        {
            _connection.Open();
            string sql = "insert into tiporaza(TIPRAZA_ID, TIPRAZA_Nombre, FKTIPMASC_ID) " +
                "values('" + model.TIPRAZA_ID + "', '" +
                model.TIPRAZA_Nombre + "', '" +
                model.FKTIPMASC_ID + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoRaza(TipoRazaModel model)
        {
            _connection.Open();
            string sql = "delete from tiporaza where TIPRAZA_ID = '" + model.TIPRAZA_ID + "'";
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
            string sql = "select CARAC_ID, CARAC_Peso, CARAC_Comportamiento, CARAC_Alimentacion from caracteristicas";
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
            string sql = "insert into caracteristicas(CARAC_ID, CARAC_Peso, CARAC_Comportamiento, CARAC_Alimentacion) " +
                "values('" + model.CARAC_ID + "', '" +
                model.CARAC_Peso + "', '" +
                model.CARAC_Comportamiento + "', '" +
                model.CARAC_Alimentacion + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarCaracteristica(CaracteristicasModel model)
        {
            _connection.Open();
            string sql = "delete from caracteristicas where CARAC_ID = '" + model.CARAC_ID + "'";
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
            string sql = "select TIPGRUP_ID, TIPGRUP_Nombre from tipogrupo";
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
            string sql = "insert into tipogrupo(TIPGRUP_ID, TIPGRUP_Nombre) " +
                "values('" + model.TIPGRUP_ID + "', '" +
                model.TIPGRUP_Nombre + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoGrupo(TipoGrupoModel model)
        {
            _connection.Open();
            string sql = "delete from tipogrupo where TIPGRUP_ID = '" + model.TIPGRUP_ID + "'";
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
            string sql = "select TIPDOC_ID, TIPDOC_Nombre from tipodocumento";
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
            string sql = "insert into tipodocumento(TIPDOC_ID, TIPDOC_Nombre) " +
                "values('" + model.TIPDOC_ID + "', '" +
                model.TIPDOC_Nombre + "')";
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public Boolean eliminarTipoDocumento(TipoDocumentoModel model)
        {
            _connection.Open();
            string sql = "delete from tipodocumento where TIPDOC_ID = '" + model.TIPDOC_ID + "'";
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

        public List<TipoMascotaModel> listarTipoMascota()
        {
            _connection.Open();
            string sql = "select TIPMASC_ID, TIPMAC_Nombre from tipomascota";
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
    }
}
