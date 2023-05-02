using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class PersonaModel
    {
        public int PER_ID { get; set; }
        public string PER_Usuario { get; set; }
        public int PER_NumeroDocumento { get; set; }
        public string PER_NombreUno { get; set; }
        public string PER_NombreDos { get; set; }
        public string PER_ApellidoUno { get; set; }
        public string PER_ApellidoDos { get; set; }
        public string PER_Correo { get; set; }
        public string PER_Contrasenia { get; set; }
        public string PER_DireccionVinda { get; set; }
        public int FKROL_ID { get; set; } = 2;
        public int FKTIPODOC_ID { get; set; }
        public int FKBAR_ID { get; set; } = 1;
        public int CantidadPublicacion { get; set; }
    }
}
