using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class BarrioModel
    {
        public int BAR_ID { get; set; }
        public string BAR_Nombre { get; set; } = null!;
        public int BAR_Estado { get; set; } = 1;
        public int FKMUN_ID { get; set; }
        public string municipio { get; set; } = null!;
    }
}
