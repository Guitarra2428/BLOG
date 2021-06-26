using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPP.AccesoDatos.Data.Repository;

namespace WebAPP.Areas.Cliente.Controllers
{
  
    public class SlidersController : Controller
    {
        private readonly IContenedorTrabajo contenedorTrabajo;

        public SlidersController( IContenedorTrabajo contenedor)
        {
            contenedorTrabajo = contenedor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        #region

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = contenedorTrabajo.slider.GetAll() });
        }
        #endregion
    }
}
