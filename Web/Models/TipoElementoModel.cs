using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoElementoModel
    {
        public int TIPELEM_ID { get; set; }
        public string TIPELEM_Nombre { get; set; } = null!;
        public int TIPELEM_Estado { get; set; } = 1;
    }
}
