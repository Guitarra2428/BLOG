using System.Linq;
using WebAPP.AccesoDatos.Data.Repository;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data
{
    public class ProyectoRepository : Repository<Proyectoswebs>, IProyectoswebs
    {

        private readonly ApplicationDbContext DDb;
        public ProyectoRepository(ApplicationDbContext context) : base(context)
        {
            DDb = context;
        }

        public void Update(Proyectoswebs proyectoswebs)
        {
            var objeto = DDb.Proyectoswebs.FirstOrDefault(s => s.Id == proyectoswebs.Id);

            objeto.Nombre = proyectoswebs.Nombre;
            objeto.Descripcion = proyectoswebs.Descripcion;
            objeto.UrlImagen = proyectoswebs.UrlImagen;
            objeto.FechaCreacion = proyectoswebs.FechaCreacion;
            objeto.CategoriaID = proyectoswebs.CategoriaID;

        }
    }
}
