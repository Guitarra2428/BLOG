using WebAPP.AccesoDatos.Data.Repository;

namespace WebAPP.AccesoDatos.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {

        private readonly ApplicationDbContext Db;

        public ContenedorTrabajo(ApplicationDbContext context)
        {
            Db = context;
            categoria = new CategoriaRepository(Db);
            articulo = new ArticuloRepository(Db);
            slider = new SliderRepository(Db);
            usuario = new UsuarioRepository(Db);
            proyecto = new ProyectoRepository(Db);
            GetEmail = new EmailRepository(Db);
        }
        public ICategoriaRepositor categoria { get; private set; }
        public IArticuloRepository articulo { get; private set; }
        public ISliderRepository slider { get; private set; }
        public IUsuarioRepositor usuario { get; private set; }

        public IProyectoswebs proyecto { get; private set; }

        public IEmailRepositor GetEmail { get; private set; }

        public void Dispose()
        {
            Db.Dispose();
        }

        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
