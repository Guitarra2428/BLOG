using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
                Sliders = contenedorTrabajo.slider.GetAll(),
                ListaArticulos = contenedorTrabajo.articulo.GetAll(),
                ListaProyecto = contenedorTrabajo.proyecto.GetAll()

            };
            return View(homeVM);
        }

        public IActionResult Detalles(int id)
        {
            var articulodesdeDB = contenedorTrabajo.articulo.GetTFirstDefault(a => a.Id == id);

            return View(articulodesdeDB);
        }

        public IActionResult ProyectoDetalles(int id)
        {
            var proyectodesdeDB = contenedorTrabajo.proyecto.GetTFirstDefault(a => a.Id == id);

            return View(proyectodesdeDB);
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
