using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebAPP.Models.VieModels
{

    public class ProyectoVM
    {
        public Proyectoswebs Proyectosweb { get; set; }

        public IEnumerable<SelectListItem> Listacategoria { get; set; }
    }
}
