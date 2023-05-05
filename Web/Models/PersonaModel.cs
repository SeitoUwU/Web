using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class PersonaModel
    {
        public int PER_ID { get; set; }
        public string PER_Usuario { get; set; } = null!;
        public int PER_NumeroDocumento { get; set; }
        public string PER_NombreUno { get; set; } = null!;
        public string PER_NombreDos { get; set; } = null!;
        public string PER_ApellidoUno { get; set; } = null!;
        public string PER_ApellidoDos { get; set; } = null!;
        public string PER_Correo { get; set; } = null!;
        public string PER_Contrasenia { get; set; } = null!;
        public string PER_DireccionVinda { get; set; } = null!;
        public Boolean PER_Estado { get; set; }
        public int FKROL_ID { get; set; } = 2;
        public int FKTIPODOC_ID { get; set; }
        public int FKBAR_ID { get; set; } = 1;
        public int CantidadPublicacion { get; set; }
    }
}
