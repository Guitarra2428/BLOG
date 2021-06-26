using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data.Repository
{
   public interface IUsuarioRepositor :IRepository<ApplicationUser>
    {

        void BloquearUsuarios(string Usuario);
        void DesbloqueUsuarios(string IdUsuario);
    }
}
