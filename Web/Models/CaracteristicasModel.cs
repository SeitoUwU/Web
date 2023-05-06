using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class CaracteristicasModel
    {
        public int CARAC_ID { get; set; }
        public string? CARAC_Peso { get; set; }
        public string CARAC_Comportamiento { get; set; } = null!;
        public string CARAC_Alimentacion { get; set; } = null!;
        public int CARAC_Estado { get; set; } = 1;
        public string Carac_caracteristicas { get; set; } = null!;
    }
}
