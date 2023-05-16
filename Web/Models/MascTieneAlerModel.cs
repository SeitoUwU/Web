using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class MascTieneAlerModel
    {
        public int MASCTIENALER_ID { get; set; }
        public  string MASCTIENALER_Tratamiento { get; set; } = null!;
        public string? MASCTIENALER_FechaInicioTratamiento { get; set; }
        public string? MASCTIENALER_FechaFinTratamiento { get; set; }
        public int FKMASC_TieneAlergia { get; set; }
        public int FKALER_ID { get; set; }
        public int FKTIPTRAT_ID { get; set; }
    }
}
