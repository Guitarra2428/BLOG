using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data.Repository
{
    public interface ISliderRepository : IRepository<Slider>
    {


        void Update(Slider slider);
    }
}
