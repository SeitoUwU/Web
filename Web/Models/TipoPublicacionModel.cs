using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoPublicacionModel
    {
        public int TIPUBLI_ID { get; set; }
        public string TIPUBLI_Tipo { get; set; } = null!;
        public Boolean TIPUBLI_Estado { get; set; }
    }
}
