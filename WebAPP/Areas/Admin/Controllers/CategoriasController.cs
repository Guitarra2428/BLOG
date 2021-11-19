using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPP.AccesoDatos.Data.Repository;
using WebAPP.Models;

namespace WebAPP.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo contenedorTrabajo;

        public CategoriasController(IContenedorTrabajo trabajo)
        {
            contenedorTrabajo = trabajo;

        }
        public IActionResult Index()
        {
            var datos = contenedorTrabajo.categoria.GetAll();

            return View(datos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categorias)
        {
            if (ModelState.IsValid)
            {
                contenedorTrabajo.categoria.Add(categorias);
                contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            Categoria categoria = new Categoria();
            categoria = contenedorTrabajo.categoria.GetT(id);

            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categorias)
        {
            if (ModelState.IsValid)
            {
                contenedorTrabajo.categoria.Update(categorias);
                contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(categorias);
        }


        #region llamadas a la api

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = contenedorTrabajo.categoria.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var datos = contenedorTrabajo.categoria.GetT(id);

            if (datos == null)
            {
                return Json(new { success = false, message = "Error borrando categoria" });

            }

            contenedorTrabajo.categoria.Remove(datos);
            contenedorTrabajo.Save();
            return Json(new { success = true, message = " categoria borrada corretamente" });



        }

        #endregion
    }
}
