namespace Web.Models
{
    public class Vistas
    {
        public int pk_idvista { get; set; }
        public string nombrevista { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public string icono { get; set; }
        public Permisos fkidpermiso { get; set; }
    }
}
