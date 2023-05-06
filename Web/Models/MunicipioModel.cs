using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class MunicipioModel
    {
        public int MUN_ID { get; set; }
        public string MUN_Nombre { get; set; } = null!;
        public int MUN_Estado { get; set; } = 1;
        public int FKDEP_ID { get; set; }
        public string departamento { get; set; } = null!;
    }
}
