using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class VacunaModel
    {
        public int VAC_ID { get; set; }
        public string VAC_Nombre { get; set; } = null!;
        public int VAC_Estado { get; set; }
        public int FKTIPVAC_ID { get; set; }
    }
}
