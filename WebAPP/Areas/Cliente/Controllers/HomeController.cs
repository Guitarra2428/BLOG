using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAPP.AccesoDatos.Data.Repository;
using WebAPP.Models;

namespace WebAPP.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo contenedorTrabajo;

        public HomeController(IContenedorTrabajo trabajo)
        {
            contenedorTrabajo = trabajo;
        }

        public IActionResult Index()
        {

            HomeVM homeVM = new HomeVM()
            {
                Sliders= contenedorTrabajo.slider.GetAll(),
                ListaArticulos=contenedorTrabajo.articulo.GetAll()

            };
            return View(homeVM);
        }

        public IActionResult Detalles(int id)
        {
            var articulodesdeDB = contenedorTrabajo.articulo.GetTFirstDefault(a => a.Id == id);

            return View(articulodesdeDB);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
