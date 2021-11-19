using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data.Repository
{
    public interface IUsuarioRepositor : IRepository<ApplicationUser>
    {

        void BloquearUsuarios(string Usuario);
        void DesbloqueUsuarios(string IdUsuario);
    }
}
