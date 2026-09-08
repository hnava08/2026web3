using System.ComponentModel.DataAnnotations;

namespace _2026web3.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateOnly dob { get; set; }

        public Pasaporte? Pasaporte { get; set; }

        // pais relationship
        [Display(Name = "País")]
        public int paisId { get; set; }
        public Pais Pais { get; set; } = null!;

        // Materia relationship

        public List<Materia> Materias { get; set; } = new List<Materia>();

    }
}
