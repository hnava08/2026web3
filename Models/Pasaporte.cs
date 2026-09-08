using System.ComponentModel.DataAnnotations;

namespace _2026web3.Models
{
    public class Pasaporte
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de pasaporte es obligatorio")]
        [Display(Name = "Número")]
        public string Numero { get; set; } = string.Empty;

        // all about the relationship
        public int personaId { get; set; }
        public Persona Persona { get; set; } = null!;
    }
}
