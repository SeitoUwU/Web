using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class PaisModel
    {
        public int PAIS_ID { get; set; }
        public string PAIS_Nombre { get; set; }
        public Boolean PAIS_Estado { get; set; }
    }
}
