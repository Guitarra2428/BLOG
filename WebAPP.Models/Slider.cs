using System.ComponentModel.DataAnnotations;

namespace WebAPP.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo Es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este Campo Es obligatorio")]
        public bool Estado { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Urlimagen { get; set; }

    }
}
