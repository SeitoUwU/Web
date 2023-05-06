using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class DepartamentoModel
    {
        public int DEP_ID { get; set; }
        public string DEP_Nombre { get; set; } = null!;
        public int DEP_Estado { get; set; } = 1;
        public int FKPAIS_ID { get; set; }
        public string pais { get; set; } = null!;
    }
}
