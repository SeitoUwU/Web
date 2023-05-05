using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class CirugiaModel
    {
        public int CIRU_ID { get; set; }
        public DateOnly? CIRU_FechaCirugia { get; set; }
        public Boolean CIRU_Estado { get; set; }
        public int FKMASC_ID { get; set; }
        public int FKTIPCIRU_ID { get; set; }
    }
}
