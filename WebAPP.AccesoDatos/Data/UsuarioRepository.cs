using System;
using System.Linq;
using WebAPP.AccesoDatos.Data.Repository;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data
{
    public class UsuarioRepository : Repository<ApplicationUser>, IUsuarioRepositor
    {


        private readonly ApplicationDbContext _Db;
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
            _Db = context;
        }

        public void BloquearUsuarios(string IdUsuario)
        {
            var usuariodesdeDb = _Db.AplicationUsers.FirstOrDefault(u => u.Id == IdUsuario);
            usuariodesdeDb.LockoutEnd = DateTime.Now.AddYears(100);
            _Db.SaveChanges();
        }

        public void DesbloqueUsuarios(string IdUsuario)
        {
            var usuariodesdeDb = _Db.AplicationUsers.FirstOrDefault(u => u.Id == IdUsuario);
            usuariodesdeDb.LockoutEnd = DateTime.Now;
            _Db.SaveChanges();
        }
    }
}
