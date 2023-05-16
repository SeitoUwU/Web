using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class CirugiaModel
    {
        public int CIRU_ID { get; set; }
        public string? CIRU_FechaCirugia { get; set; }
        public int CIRU_Estado { get; set; } = 1;
        public int FKMASC_ID { get; set; }
        public int FKTIPCIRU_ID { get; set; }
    }
}
