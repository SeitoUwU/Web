using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class RolModel
    {
        public int ROL_ID { get; set; }
        public string ROL_Nombre { get; set; } = null!;
        public int ROL_Estado { get; set; } = 1;
    }
}
