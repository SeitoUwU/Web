using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class PerReportaGrupoModel
    {
        public int REPOR_ID { get; set; }
        public DateOnly? REPOR_FechaReporte { get; set; }
        public Boolean REPOR_EstadoReporte { get; set; }
        public int FKMOT_ID { get; set; }
        public int FKPER_Reporta { get; set; }
        public int FKPUBLI_Reportan { get; set; }
    }
}
