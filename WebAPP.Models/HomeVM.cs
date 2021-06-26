using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPP.Models
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Articulo> ListaArticulos { get; set; }


    }
}
