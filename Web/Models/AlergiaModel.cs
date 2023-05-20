using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class AlergiaModel
    {
        public int ALER_ID { get; set; }
        public string ALER_NombreAlergia { get; set; } = null!;
        public int ALER_Estado { get; set; }
        public TipoAlergiaModel TipoAlergia { get; set; } = null!;
    }
}
