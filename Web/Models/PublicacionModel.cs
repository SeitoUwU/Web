using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Models
{
    public class PublicacionModel
    {
        public int PUBLI_ID { get; set; }
        public string PUBLI_Titulo { get; set; }
        public string PUBLI_Descripcion { get; set; }
        public Boolean PUBLI_Estado { get; set; }
        public int PUBLI_Total { get; set; }
        public int FKPER_RealizaPublicacion { get; set; }
        public int FKTIPUBLI_ID { get; set; }
        public int FKFOR_ID { get; set; }
    }
}
