using BibliotecaAutoresLibros.Data;
using BibliotecaAutoresLibros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAutoresLibros.Pages.Libros;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Libro Libro { get; set; } = new();

    public SelectList Autores { get; set; } = default!;

    public async Task OnGetAsync()
    {
        await CargarAutoresAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // La navegación Autor no viaja en el formulario, solo AutorId
        ModelState.Remove($"{nameof(Libro)}.{nameof(Libro.Autor)}");

        if (!await _context.Autores.AnyAsync(a => a.Id == Libro.AutorId))
        {
            ModelState.AddModelError($"{nameof(Libro)}.{nameof(Libro.AutorId)}",
                "Debe seleccionar un autor válido.");
        }

        if (!ModelState.IsValid)
        {
            await CargarAutoresAsync();
            return Page();
        }

        _context.Libros.Add(Libro);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Se registró el libro \"{Libro.Titulo}\".";
        return RedirectToPage("./Index");
    }

    private async Task CargarAutoresAsync()
    {
        Autores = new SelectList(
            await _context.Autores.OrderBy(a => a.NombreCompleto).ToListAsync(),
            nameof(Autor.Id),
            nameof(Autor.NombreCompleto));
    }
}
