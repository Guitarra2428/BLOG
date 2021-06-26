using System;
using System.Collections.Generic;
using System.Text;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data.Repository
{
   public interface IArticuloRepository :IRepository<Articulo>
    {

        //IEnumerable<SelectListItem> GetListaCategoria();

        void Update(Articulo articulo);
    }
}
