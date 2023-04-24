namespace Web.Models
{
    public class PerIngresaGrupoModel
    {
        public int FKGRUP_ID { get; set; }
        public int FKPER_ID { get; set; }
        public DateOnly? INGR_FechaIngreso { get; set; }
        public Boolean INGR_EstadoIngreso { get; set; }
    }
}
