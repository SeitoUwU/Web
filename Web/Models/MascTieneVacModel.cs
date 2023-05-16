using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class MascTieneVacModel
    {
        public int MASCTIENVAC_ID { get; set; }
        public string? MASCTIENVAC_FechaAplicacion { get; set; }
        public int FKMASC_Aplicacion { get; set; }
        public int FKVAC_ID { get; set; }
    }
}
