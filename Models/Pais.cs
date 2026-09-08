using System.ComponentModel.DataAnnotations;

namespace _2026web3.Models
{
    public class Pais
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del país es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = string.Empty;

        public List<Persona> Personas { get; set; } = new List<Persona>();

    }
}
