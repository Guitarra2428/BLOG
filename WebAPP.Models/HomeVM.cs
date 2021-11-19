using System.Collections.Generic;

namespace WebAPP.Models
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Articulo> ListaArticulos { get; set; }
        public IEnumerable<Proyectoswebs> ListaProyecto { get; set; }

    }
}
