using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoTratamientoModel
    {
        public int TIPTRAT_ID { get; set; }
        public string TIPTRAT_Nombre { get; set; } = null!;
    }
}
