using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoMascotaModel
    {
        public int TIPMASC_ID { get; set; }
        public string TIPMASC_Nombre { get; set; } = null!;
        public Boolean TIPMASC_Estado { get; set; }
    }

}
