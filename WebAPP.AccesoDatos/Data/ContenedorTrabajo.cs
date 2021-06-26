using System;
using System.Collections.Generic;
using System.Text;
using WebAPP.AccesoDatos.Data.Repository;

namespace WebAPP.AccesoDatos.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {

        private readonly ApplicationDbContext Db;

        public ContenedorTrabajo( ApplicationDbContext context)
        {
            Db = context;
            categoria = new CategoriaRepository(Db);
            articulo = new ArticuloRepository(Db);
            slider = new SliderRepository(Db);
            usuario = new UsuarioRepository(Db);
        }
        public ICategoriaRepositor categoria { get; private set;}
        public IArticuloRepository articulo { get; private set;}
        public ISliderRepository slider{ get; private set;}
        public IUsuarioRepositor usuario { get; private set; }

        public void Dispose()
        {
            Db.Dispose();
        }

        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
