﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using MySql.Data.MySqlClient;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly MySqlConnection connection;

        public AdministradorController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult createTipoVacuna(int idTipoVacuna, string nombreTipoVacuna)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoVacunaModel tipoVacunaModel = new TipoVacunaModel();
            tipoVacunaModel.TIPVAC_ID = idTipoVacuna;
            tipoVacunaModel.TIPVAC_Nombre = nombreTipoVacuna;
            admin.insertarTipoVacuna(tipoVacunaModel);
            return RedirectToAction("AdminAgregaTipoVacuna");
        }

        public ActionResult AdminEliminaTipoVacuna()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoVacuna());
        }

        public ActionResult deleteTipoVacuna(int idTipoVacuna)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoVacunaModel tipoVacunaModel = new TipoVacunaModel();
            tipoVacunaModel.TIPVAC_ID = idTipoVacuna;
            admin.eliminarTipoVacuna(tipoVacunaModel);
            return RedirectToAction("AdminEliminaTipoVacuna");
        }

        public ActionResult AdminActualizaTipoVacuna()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listarTipoVacuna());
        }

        public ActionResult updateTipoVacuna(int idTipoVacuna, string nombreTipoVacuna)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            TipoVacunaModel tipoVacunaModel = new TipoVacunaModel();
            tipoVacunaModel.TIPVAC_ID = idTipoVacuna;
            tipoVacunaModel.TIPVAC_Nombre = nombreTipoVacuna;
            admin.actualizarTipoVacuna(tipoVacunaModel);
            return RedirectToAction("AdminActualizaTipoVacuna");
        }

        public ActionResult AdminReportes()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            List<PublicacionModel> publicaciones = admin.listarPublicaciones();
            return View(publicaciones);
        }
        
        [HttpPost]
        public ActionResult DesactivarPublicacion(int id)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.DesactivarPublicacion(id);
            return RedirectToAction("AdminReportes");
        }



    }
}
