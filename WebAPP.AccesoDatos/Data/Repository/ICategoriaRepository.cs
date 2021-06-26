using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data.Repository
{
   public interface ICategoriaRepositor :IRepository<Categoria>
    {

        IEnumerable<SelectListItem> GetListaCategoria();

        void Update(Categoria categoria);
    }
}
