using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class ElementosModel
    {
        public int ELEM_ID { get; set; }
        public string ELEM_Nombre { get; set; } = null!;
        public string ELEM_Descripcion { get; set; } = null!;
        public int ELEM_Valor { get; set; }
        public Boolean ELEM_Estado { get; set; }
        public int FKPUBLI_ID { get; set; }
        public int FKTIPELEM_ID { get; set; }
    }
}
