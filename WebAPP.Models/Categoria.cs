using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPP.Models
{
   public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Ingrese un nombre para este campo")]
        [Display(Name ="Nombre categoria")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Orden de visualizacion")]
        public int Orden { get; set; }


    }
}
