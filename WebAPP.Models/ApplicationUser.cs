
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebAPP.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required(ErrorMessage = "Este Campo ES Obligatorio")]
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Este Campo ES Obligatorio")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Este Campo ES Obligatorio")]
        public string Pais { get; set; }

    }
}

