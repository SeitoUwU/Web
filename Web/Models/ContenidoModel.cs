namespace Web.Models
{
    public class ContenidoModel
    {
        public List<DepartamentoModel>? departamentos { get; set; }
        public List<PaisModel>? paises { get; set; }
        public List<MunicipioModel>? municipios { get; set; }
        public List<BarrioModel>? barrios { get; set; } 
        public List<TipoRazaModel>? tiposRaza { get; set; }
        public List<TipoMascotaModel>? tiposMascota { get; set; }
        public PersonaModel persona { get; set; } = null!;
        public List<PublicacionModel>? publicaciones { get; set; }
    }
}
