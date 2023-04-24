using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoRazaModel
    {
        public int TIPRAZA_ID { get; set; }
        public string TIPRAZA_Nombre { get; set; } = null!;
        public int FKTIPMASC_ID { get; set; }

    }
}
