using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WebAPP.AccesoDatos.Data.Repository;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepositor
    {

        private readonly ApplicationDbContext DDb;
        public CategoriaRepository(ApplicationDbContext context) : base(context)
        {
            DDb = context;
        }
        public IEnumerable<SelectListItem> GetListaCategoria()
        {
            return DDb.Categorias.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()

            });
        }

        public void Update(Categoria categoria)
        {
            var objDesdeDb = DDb.Categorias.FirstOrDefault(s => s.Id == categoria.Id);
            objDesdeDb.Nombre = categoria.Nombre;
            objDesdeDb.Orden = categoria.Orden;

            Db.SaveChanges();
        }
    }
}
