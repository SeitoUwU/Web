using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class MotivoReporteModel
    {
        public int MOT_ID { get; set; }
        public string MOT_MotivoReporte { get; set; } = null!;
    }
}
