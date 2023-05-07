using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoMascotaModel
    {
        public int TIPMASC_ID { get; set; }
        public string TIPMASC_Nombre { get; set; } = null!;
        public int TIPMASC_Estado { get; set; } = 1;
    }

}
