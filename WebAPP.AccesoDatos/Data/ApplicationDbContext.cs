using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Proyectoswebs> Proyectoswebs { get; set; }
        public DbSet<Email> Emails { get; set; }


        public DbSet<ApplicationUser> AplicationUsers { get; set; }

    }
}
