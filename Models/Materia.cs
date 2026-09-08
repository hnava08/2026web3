using System.ComponentModel.DataAnnotations;

namespace _2026web3.Models
{
    public class Materia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la materia es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }=string.Empty;

        [Range(0, 100, ErrorMessage = "Los créditos deben estar entre 0 y 100")]
        public int Creditos { get; set; }

        // relationship with Persona
        public List<Persona> Personas { get; set; } = new List<Persona>();
    }
}
