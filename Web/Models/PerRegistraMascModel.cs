using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class PerRegistraMascModel
    {
        public int PERREGISMASC_ID { get; set; }
        public DateOnly? PERREGISMASC_FechaRegistro { get; set; }
        public Boolean PERREGISMASC_Estado { get; set; }
        public int FKPER_Registra { get; set; }
        public int FKMASC_ID { get; set; }
    }
}
