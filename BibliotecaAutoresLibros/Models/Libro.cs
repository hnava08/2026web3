using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAutoresLibros.Models;

public class Libro : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    [Display(Name = "Título")]
    [StringLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El año de publicación es obligatorio.")]
    [Display(Name = "Año de publicación")]
    public int AnioPublicacion { get; set; }

    [Display(Name = "Disponibilidad")]
    public bool Disponibilidad { get; set; } = true;

    // Clave foránea hacia Autor
    [Required(ErrorMessage = "Debe seleccionar un autor.")]
    [Display(Name = "Autor")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un autor válido.")]
    public int AutorId { get; set; }

    [ForeignKey(nameof(AutorId))]
    public Autor? Autor { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var anioActual = DateTime.Now.Year;
        if (AnioPublicacion < 1450 || AnioPublicacion > anioActual)
        {
            yield return new ValidationResult(
                $"El año de publicación debe estar entre 1450 y {anioActual}.",
                new[] { nameof(AnioPublicacion) });
        }
    }
}
