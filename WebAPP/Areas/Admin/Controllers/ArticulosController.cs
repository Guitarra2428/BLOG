using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using WebAPP.AccesoDatos.Data.Repository;
using WebAPP.Models.VieModels;

namespace WebAPP.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment HostEnvironment;
        int s = 3;
        public ArticulosController(IContenedorTrabajo trabajo, IWebHostEnvironment iwebHostEnvironment)
        {
            _contenedorTrabajo = trabajo;
            HostEnvironment = iwebHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {


            return View();
        }



        [HttpGet]
        public IActionResult Create()
        {
            ArticuloVM articulo = new ArticuloVM()
            {

                Articulo = new Models.Articulo(),
                Listacategoria = _contenedorTrabajo.categoria.GetListaCategoria()
            };

            return View(articulo);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticuloVM articuloVM)
        {
            if (ModelState.IsValid)
            {
                string rutaprincipal = HostEnvironment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;

                if (articuloVM.Articulo.Id == 0)
                {
                    string nombrearchivo = Guid.NewGuid().ToString();
                    var subida = Path.Combine(rutaprincipal, @"imagenes\articulos");
                    var extencion = Path.GetExtension(archivo[0].FileName);

                    using (var filleStreams = new FileStream(Path.Combine(subida, nombrearchivo + extencion), FileMode.Create))
                    {
                        archivo[0].CopyTo(filleStreams);
                    }


                    articuloVM.Articulo.UrlImagen = @"\imagenes\articulos\" + nombrearchivo + extencion;
                    articuloVM.Articulo.FechaCreacion = DateTime.Now.ToString();


                    _contenedorTrabajo.articulo.Add(articuloVM.Articulo);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));


                }



            }
            articuloVM.Listacategoria = _contenedorTrabajo.categoria.GetListaCategoria();
            return View(articuloVM);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ArticuloVM articulo = new ArticuloVM()
            {

                Articulo = new Models.Articulo(),
                Listacategoria = _contenedorTrabajo.categoria.GetListaCategoria()
            };

            if (id != null)
            {
                articulo.Articulo = _contenedorTrabajo.articulo.GetT(id.GetValueOrDefault());
            }

            return View(articulo);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArticuloVM articuloVM)
        {
            if (ModelState.IsValid)
            {
                string rutaprincipal = HostEnvironment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;

                var articulodb = _contenedorTrabajo.articulo.GetT(articuloVM.Articulo.Id);

                if (archivo.Count() > 0)
                {
                    //editar imagen
                    string nombrearchivo = Guid.NewGuid().ToString();
                    var subida = Path.Combine(rutaprincipal, @"imagenes\articulos");
                    var extencion = Path.GetExtension(archivo[0].FileName);
                    var nuevaextesion = Path.GetExtension(archivo[0].FileName);

                    var rutaimagen = Path.Combine(rutaprincipal, articulodb.UrlImagen.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaimagen))
                    {
                        System.IO.File.Delete(rutaimagen);
                    }
                    using (var filleStreams = new FileStream(Path.Combine(subida, nombrearchivo + nuevaextesion), FileMode.Create))
                    {
                        archivo[0].CopyTo(filleStreams);
                    }


                    articuloVM.Articulo.UrlImagen = @"\imagenes\articulos\" + nombrearchivo + nuevaextesion;
                    articuloVM.Articulo.FechaCreacion = DateTime.Now.ToString();





                }
                else
                {
                    //si existe debe conservar la que tiene
                    articuloVM.Articulo.UrlImagen = articulodb.UrlImagen;

                }
                _contenedorTrabajo.articulo.Update(articuloVM.Articulo);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));




            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var desdeDB = _contenedorTrabajo.articulo.GetT(id);
            string rutadirectorioprincipal = HostEnvironment.WebRootPath;
            var rutaimagen = Path.Combine(rutadirectorioprincipal, desdeDB.UrlImagen.TrimStart('\\'));


            if (System.IO.File.Exists(rutaimagen))
            {
                System.IO.File.Delete(rutaimagen);
            }

            if (desdeDB == null)
            {
                return Json(new { success = false, message = "erro borrar articulo" });
            }
            _contenedorTrabajo.articulo.Remove(desdeDB);

            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "articulo borrado con exito" });


        }

        #region llamadas a la api

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.articulo.GetAll(includeProperties: "Categoria") });
        }



        #endregion
    }
}
