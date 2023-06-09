﻿using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Web.Datos;
using Web.Models;

namespace Web.Controllers
{
    public class PaisController : Controller
    {
        private readonly MySqlConnection connection;

        public PaisController(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public ActionResult AdminAgregaPais()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listaPaises());
        }

        [HttpPost]
        public ActionResult createPais(int idPais, string nombrePais)
        {
            PaisModel pais = new PaisModel();
            pais.PAIS_ID = idPais;
            pais.PAIS_Nombre = nombrePais;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.insertarPais(pais);
            return RedirectToAction("AdminAgregaPais");
        }

        public ActionResult AdminActualizaPais()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listaPaises());
        }

        public ActionResult ActualizarPais(int idPais, string nombrePais)
        {
            PaisModel pais = new PaisModel();
            pais.PAIS_ID = idPais;
            pais.PAIS_Nombre = nombrePais;
            AdministradorDatos admin = new AdministradorDatos(connection);
            admin.ActualizarPais(pais);
            return RedirectToAction("AdminActualizaPais");
        }

        public ActionResult AdminEliminaPais()
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            return View(admin.listaPaises());
        }

        public ActionResult deletePais(int idPais)
        {
            AdministradorDatos admin = new AdministradorDatos(connection);
            PaisModel pais = new PaisModel();
            pais.PAIS_ID = idPais;
            admin.EliminarPais(pais);
            return RedirectToAction("AdminEliminaPais");
        }
    }
}
