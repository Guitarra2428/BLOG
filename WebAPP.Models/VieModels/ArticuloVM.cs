using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebAPP.Models.VieModels
{

    public class ArticuloVM
    {
        public Articulo Articulo { get; set; }

        public IEnumerable<SelectListItem> Listacategoria { get; set; }
    }
}
