﻿using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class GrupoModel
    {
        public int GRUP_ID { get; set; }
        public string GRUP_Nombre { get; set; }
        public string GRUP_Descripcion { get; set; }
        public Boolean GRUP_Estado { get; set; }
        public int FKPER_Crea { get; set; }
        public int FKTIPGRUP_ID { get; set; }
    }
}
