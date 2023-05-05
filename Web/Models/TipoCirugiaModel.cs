using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoCirugiaModel
    {
        public int TIPCIRU_ID { get; set; }
        public string TIPCIRU_Nombre { get; set; } = null!;
        public Boolean TIPCIRU_Estado { get; set; }
    }
}
