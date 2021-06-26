using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPP.AccesoDatos.Data.Repository;
using WebAPP.Models;

namespace WebAPP.AccesoDatos.Data
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {

        private readonly ApplicationDbContext DDb;
        public ArticuloRepository(ApplicationDbContext context):base(context)
        {
            DDb = context;
        }

        public void Update(Articulo articulo)
        {
            var objeto = DDb.Articulos.FirstOrDefault(s => s.Id == articulo.Id);

            objeto.Nombre = articulo.Nombre;
            objeto.Descripcion = articulo.Descripcion;
            objeto.UrlImagen = articulo.UrlImagen;
            objeto.FechaCreacion = articulo.FechaCreacion;
            objeto.CategoriaID = articulo.CategoriaID;

        }
    }
}
