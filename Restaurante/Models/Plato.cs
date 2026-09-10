using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class Plato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999, ErrorMessage = "El precio debe ser mayor que 0")]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Display(Name = "Disponible")]
        public bool Disponible { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoria")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
