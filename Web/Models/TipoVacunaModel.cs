using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoVacunaModel
    {
        public int TIPVAC_ID { get; set; }
        public string TIPVAC_Nombre { get; set; } = null!;
    }
}
