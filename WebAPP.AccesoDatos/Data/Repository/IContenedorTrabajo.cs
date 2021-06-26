using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPP.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo: IDisposable
    {

        ICategoriaRepositor categoria { get;  }
        IArticuloRepository articulo { get; }
        ISliderRepository slider { get; }
        IUsuarioRepositor usuario { get; }

        void Save();
    }
}
