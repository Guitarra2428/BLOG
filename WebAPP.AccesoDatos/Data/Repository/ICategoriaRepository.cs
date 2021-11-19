using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data.Repository
{
    public interface ICategoriaRepositor : IRepository<Categoria>
    {

        IEnumerable<SelectListItem> GetListaCategoria();

        void Update(Categoria categoria);
    }
}
