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
        public PersonaModel persona { get; set; } = null!;
        public PublicacionModel? publicacion { get; set; }
        public ElementosModel? elementos { get; set; }
        public TipoPublicacionModel? tipoPublicacion { get; set; }
        public MascotaModel? mascota { get; set; }
        public MascTieneVacModel mascTieneVac { get; set; } = null!;
        public MascTieneAlerModel MascTieneAler { get; set; } = null!;
        public CirugiaModel cirugia { get; set; } = null!;
        public List<PerRegistraMascModel>? perregistraMasc { get; set; }

        public byte[] Imagen { get; set; }

    }
}
