using System;

namespace WebAPP.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {

        ICategoriaRepositor categoria { get; }
        IArticuloRepository articulo { get; }
        ISliderRepository slider { get; }
        IUsuarioRepositor usuario { get; }
        IProyectoswebs proyecto { get; }
        IEmailRepositor GetEmail { get; }


        void Save();
    }
}
