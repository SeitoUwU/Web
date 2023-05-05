using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class BarrioModel
    {
        public int BAR_ID { get; set; }
        public string BAR_Nombre { get; set; } = null!;      
        public Boolean BAR_Estado { get; set; }
        public int FKMUN_ID { get; set; }
    }
}
