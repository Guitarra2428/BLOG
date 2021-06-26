using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPP.Models.VieModels
{
   
  public  class ArticuloVM
    {
        public Articulo Articulo { get; set; }

        public IEnumerable<SelectListItem> Listacategoria { get; set; }
    }
}
