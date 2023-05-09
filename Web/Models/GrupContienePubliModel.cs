using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class GrupContienePubliModel
    {
        public int GRUPUBLI_ID { get; set; }
        public DateOnly? GRUPUBLI_FechaAgregacion { get; set; }
        public int GRUPUBLI_Estado { get; set; } = 1;
        public int FKGRUP_ID { get; set; }
        public int FKPUBLI_ID { get; set; }
    }
}
