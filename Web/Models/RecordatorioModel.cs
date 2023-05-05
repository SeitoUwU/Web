using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class RecordatorioModel
    {
        public int RECOR_ID { get; set; }
        public DateOnly? RECOR_FechaInicioRecordatorio { get; set; }
        public DateOnly? RECOR_FechaFinRecordatorio { get; set; }
        public Boolean RECOR_Estado { get; set; }
        public int FKPER_RealizaRecordatorio { get; set; }
    }
}
