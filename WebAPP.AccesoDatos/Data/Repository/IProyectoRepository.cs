using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data.Repository
{
    public interface IProyectoswebs : IRepository<Proyectoswebs>
    {

        //IEnumerable<SelectListItem> GetListaCategoria();

        void Update(Proyectoswebs proyectoswebs);
    }
}
