using Microsoft.AspNetCore.Mvc;
using WebAPP.AccesoDatos.Data.Repository;
using WebAPP.Models;

namespace WebAPP.Controllers
{
    [Area("Cliente")]
    public class EmailsController : Controller
    {
        //private readonly ApplicationDbContext applicationDb;
        private readonly IContenedorTrabajo applicationDb;

        public EmailsController(IContenedorTrabajo _applicationDb)
        {
            applicationDb = _applicationDb;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Email email)
        {
            if (ModelState.IsValid)
            {
                applicationDb.GetEmail.Add(email);
                applicationDb.Save();
                return RedirectToAction(nameof(Create));

            }

            //if (ModelState.IsValid)
            //{
            //    applicationDb.Emails.Add(email);
            //    applicationDb.SaveChanges();
            //    return RedirectToAction(nameof(Index));

            //}
            return View(email);
        }
        #region Api

        [HttpGet]
        public IActionResult GetAll()
        {
            // var datos = applicationDb.Emails.Find(id);

            return Json(new { data = applicationDb.GetEmail.GetAll() });
        }
        #endregion



    }
}
