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
        public List<PublicacionModel>? publicaciones { get; set; }
        public List<PerRegistraMascModel>? perregistraMasc { get; set; }
        public PersonaModel persona { get; set; } = null!;
        public TipoDocumentoModel tipoDocumento { get; set; }
        public PaisModel pais { get; set; }
        public DepartamentoModel departamento { get; set; }
        public MunicipioModel municipio { get; set; }
        public BarrioModel barrio { get; set; }
        public PublicacionModel? publicacion { get; set; }
        public ElementosModel? elementos { get; set; }
        public TipoPublicacionModel? tipoPublicacion { get; set; }
        public MascotaModel? mascota { get; set; }
        public MascTieneVacModel mascTieneVac { get; set; } = null!;
        public MascTieneAlerModel MascTieneAler { get; set; } = null!;
        public CirugiaModel cirugia { get; set; } = null!;
        public byte[] Imagen { get; set; }

    }
}
