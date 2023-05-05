using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoDocumentoModel
    {
        public int TIPDOC_ID { get; set; }
        public string TIPDOC_Nombre { get; set; } = null!;
        public Boolean TIPDOC_Estado { get; set; }
    }

}
