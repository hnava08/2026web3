using System.ComponentModel.DataAnnotations;

namespace BibliotecaAutoresLibros.Models;

public class Autor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre completo es obligatorio.")]
    [Display(Name = "Nombre completo")]
    [StringLength(150)]
    public string NombreCompleto { get; set; } = string.Empty;

    [Display(Name = "Nacionalidad")]
    [StringLength(100)]
    public string? Nacionalidad { get; set; }

    // Relación uno a muchos: un autor puede tener muchos libros
    public List<Libro> Libros { get; set; } = new();
}
