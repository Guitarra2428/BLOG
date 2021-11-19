using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPP.Models
{

    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Nombre del articulo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Descripcion De Articulo")]
        public string Descripcion { get; set; }
        [Display(Name = "Fecha de Creacion")]
        public string FechaCreacion { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        [Required]
        public int CategoriaID { get; set; }

        [ForeignKey("CategoriaID")]
        public virtual Categoria Categoria { get; set; }
    }
}
