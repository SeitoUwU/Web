using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class MascotaModel
    {
        public int MASC_ID { get; set; }
        public string MASC_Nombre { get; set; } = null!;
        public int MASC_Edad { get; set; }
        public string MASC_Descripcion { get; set; } = null!;
        public Boolean MASC_Estado { get; set; }
        public int FKGENMASC_ID { get; set; }
        public int FKPUBLI_ID { get; set; }
        public int FKCARAC_ID { get; set; }
        public int FKTIPRAZA_ID { get; set; }

      
    }
}
