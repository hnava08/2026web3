using BibliotecaAutoresLibros.Data;
using BibliotecaAutoresLibros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BibliotecaAutoresLibros.Pages.Autores;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Autor Autor { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // La colección de libros no viaja en el formulario
        ModelState.Remove($"{nameof(Autor)}.{nameof(Autor.Libros)}");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Autores.Add(Autor);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Se registró el autor \"{Autor.NombreCompleto}\".";
        return RedirectToPage("./Index");
    }
}
