using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoViviendaModel
    {
        public int TIPVIVI_ID { get; set; }
        public string TIPVIVI_Vivienda { get; set; } = null!;
    }
}
