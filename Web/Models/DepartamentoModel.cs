using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class DepartamentoModel
    {
        public int DEP_ID { get; set; }
        public string DEP_Nombre { get; set; }
        public int FKPAIS_ID { get; set; }
    }
}
