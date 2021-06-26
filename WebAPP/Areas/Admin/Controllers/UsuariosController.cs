using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPP.AccesoDatos.Data.Repository;

namespace WebAPP.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class UsuariosController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            var claimIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioactual = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return View(_contenedorTrabajo.usuario.GetAll(u => u.Id != usuarioactual.Value));
        }

        public IActionResult Bloquear( string id)
        {
            if (id==null)
            {
                return NotFound();

            }
            _contenedorTrabajo.usuario.BloquearUsuarios(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Desbloquear(string id)
        {
            if (id == null)
            {
                return NotFound();

            }
            _contenedorTrabajo.usuario.DesbloqueUsuarios(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
