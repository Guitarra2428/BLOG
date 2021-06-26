using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPP.AccesoDatos.Data.Repository;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data
{
   public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext dbslider;

        public SliderRepository(ApplicationDbContext context) : base(context)
        {
           dbslider = context;
        }

        public void Update(Slider slider)
        {
            var objeto = dbslider.Sliders.FirstOrDefault(s=> s.Id==s.Id);

            objeto.Id = slider.Id;
            objeto.Nombre = slider.Nombre;
            objeto.Estado = slider.Estado;
            objeto.Urlimagen = slider.Urlimagen;

            dbslider.SaveChanges();

        }
    }
}
