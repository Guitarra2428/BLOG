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
    public class ProyectoswebsController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment HostEnvironment;
        public ProyectoswebsController(IContenedorTrabajo trabajo, IWebHostEnvironment iwebHostEnvironment)
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
            ProyectoVM proyecto = new ProyectoVM()
            {

                Proyectosweb = new Models.Proyectoswebs(),
                Listacategoria = _contenedorTrabajo.categoria.GetListaCategoria()
            };

            return View(proyecto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProyectoVM proyectoVM)
        {
            if (ModelState.IsValid)
            {
                string rutaprincipal = HostEnvironment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;

                if (proyectoVM.Proyectosweb.Id == 0)
                {
                    string nombrearchivo = Guid.NewGuid().ToString();
                    var subida = Path.Combine(rutaprincipal, @"imagenes\articulos");
                    var extencion = Path.GetExtension(archivo[0].FileName);

                    using (var filleStreams = new FileStream(Path.Combine(subida, nombrearchivo + extencion), FileMode.Create))
                    {
                        archivo[0].CopyTo(filleStreams);
                    }


                    proyectoVM.Proyectosweb.UrlImagen = @"\imagenes\articulos\" + nombrearchivo + extencion;
                    proyectoVM.Proyectosweb.FechaCreacion = DateTime.Now.ToString();


                    _contenedorTrabajo.proyecto.Add(proyectoVM.Proyectosweb);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));


                }



            }
            proyectoVM.Listacategoria = _contenedorTrabajo.categoria.GetListaCategoria();
            return View(proyectoVM);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ProyectoVM proyecto = new ProyectoVM()
            {

                Proyectosweb = new Models.Proyectoswebs(),
                Listacategoria = _contenedorTrabajo.categoria.GetListaCategoria()
            };

            if (id != null)
            {
                proyecto.Proyectosweb = _contenedorTrabajo.proyecto.GetT(id.GetValueOrDefault());
            }

            return View(proyecto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProyectoVM proyectoVM)
        {
            if (ModelState.IsValid)
            {
                string rutaprincipal = HostEnvironment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;

                var proyectodb = _contenedorTrabajo.articulo.GetT(proyectoVM.Proyectosweb.Id);

                if (archivo.Count() > 0)
                {
                    //editar imagen
                    string nombrearchivo = Guid.NewGuid().ToString();
                    var subida = Path.Combine(rutaprincipal, @"imagenes\articulos");
                    var extencion = Path.GetExtension(archivo[0].FileName);
                    var nuevaextesion = Path.GetExtension(archivo[0].FileName);

                    var rutaimagen = Path.Combine(rutaprincipal, proyectodb.UrlImagen.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaimagen))
                    {
                        System.IO.File.Delete(rutaimagen);
                    }
                    using (var filleStreams = new FileStream(Path.Combine(subida, nombrearchivo + nuevaextesion), FileMode.Create))
                    {
                        archivo[0].CopyTo(filleStreams);
                    }

                    proyectoVM.Proyectosweb.UrlImagen = @"\imagenes\articulos\" + nombrearchivo + nuevaextesion;
                    proyectoVM.Proyectosweb.FechaCreacion = DateTime.Now.ToString();

                }
                else
                {
                    //si existe debe conservar la que tiene
                    proyectoVM.Proyectosweb.UrlImagen = proyectodb.UrlImagen;

                }
                _contenedorTrabajo.proyecto.Update(proyectoVM.Proyectosweb);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var desdeDB = _contenedorTrabajo.proyecto.GetT(id);
            string rutadirectorioprincipal = HostEnvironment.WebRootPath;
            var rutaimagen = Path.Combine(rutadirectorioprincipal, desdeDB.UrlImagen.TrimStart('\\'));


            if (System.IO.File.Exists(rutaimagen))
            {
                System.IO.File.Delete(rutaimagen);
            }

            if (desdeDB == null)
            {
                return Json(new { success = false, message = "erro borrar proyecto" });
            }
            _contenedorTrabajo.proyecto.Remove(desdeDB);

            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "proyecto borrado con exito" });


        }

        #region llamadas a la api

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.proyecto.GetAll(includeProperties: "Categoria") });
        }



        #endregion
    }
}
