using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class AlergiaModel
    {
        public int ALER_ID { get; set; }
        public string ALER_NombreAlergia { get; set; } = null!;
        public Boolean ALER_Estado { get; set; }
        public int FKTIPALER_ID { get; set; }
    }
}
