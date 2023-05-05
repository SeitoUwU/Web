using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class GeneroMascotaModel
    {
        public int GENMASC_ID { get; set; }
        public string GENMASC_Nombre { get; set; } = null!;
        public Boolean GENMASC_Estado { get; set; }
    }
}
