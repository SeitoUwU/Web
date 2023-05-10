using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class PublicacionModel
    {
        public int PUBLI_ID { get; set; }
        public string PUBLI_Titulo { get; set; }
        public string PUBLI_Descripcion { get; set; }
        public int PUBLI_Estado { get; set; } = 1;
        public int PUBLI_Cantidad { get; set; } = 0;
        public int? PUBLI_Total { get; set; } = null;
        public int FKPER_RealizaPublicacion { get; set; }
        public int FKTIPUBLI_ID { get; set; }
        public int? FKFOR_ID { get; set; } = null;
    }
}
