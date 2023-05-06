using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class TipoGrupoModel
    {
        public int TIPGRUP_ID { get; set; }
        public string TIPGRUP_Nombre { get; set; } = null!;
        public int TIPGRUP_Estado { get; set; } = 1;
    }
}
