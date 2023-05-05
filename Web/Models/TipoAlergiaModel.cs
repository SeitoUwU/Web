using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class TipoAlergiaModel
    {
        public int TIPALER_ID { get; set; }
        public string? TIPALER_Nombre { get; set; }
        public Boolean TIPALER_Estado { get; set; }

    }
}
