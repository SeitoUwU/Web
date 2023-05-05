using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class FormularioModel
    {
        public int FOR_ID { get; set; }
        public int FOR_Contacto { get; set; } 
        public string FOR_MotivoAdopcion { get; set; } = null!;
        public int FOR_CantidadPersonasVivienda { get; set; }
        public Boolean FOR_Estado { get; set; } = false;
        public string FOR_MotivoRechazo { get; set; } = null!;
        public string FOR_CasaSegura { get; set; } = null!;
        public string FOR_AlergiaEnCasa { get; set; } = null!;
        public string FOR_UbicacionCasa { get; set; } = null!;
        public string FOR_EnfermedadesRespiratoriasEnCasa { get; set; } = null!;
        public int FKPER_Llena { get; set; }
        public int FKMASC_ID { get; set; }
        public int FKTIPVIVI_ID { get; set; }
    }
}
