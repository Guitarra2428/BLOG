using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebAPP.Models;
using WebAPP.Utilidades;

namespace WebAPP.AccesoDatos.Data.Inicializador
{
    public class InicializadorDB : IInicializadorDB
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InicializadorDB(ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Inicializar()
        {

            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {


            }

            if (_db.Roles.Any(ro => ro.Name == CNT.Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(CNT.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Usuarios)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Admin@Guitarra2428.com",
                Email = "Admin@Guitarra2428.com",
                EmailConfirmed = true,
                Nombre = "Luis"

            }, "Guitarra2428@").GetAwaiter().GetResult();

            ApplicationUser usuario = _db.AplicationUsers
                .Where(us => us.Email == "Admin@Guitarra2428.com").FirstOrDefault();
            _userManager.AddToRoleAsync(usuario, CNT.Admin).GetAwaiter().GetResult();
        }
    }
}
