using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class GrupoModel
    {
        public int GRUP_ID { get; set; }
        public string GRUP_Nombre { get; set; }
        public string GRUP_Descripcion { get; set; }
        public int GRUP_Estado { get; set; } = 1;
        public int FKPER_Crea { get; set; }
        public int FKTIPGRUP_ID { get; set; }
    }
}
