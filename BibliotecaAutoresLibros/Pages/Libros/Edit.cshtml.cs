using BibliotecaAutoresLibros.Data;
using BibliotecaAutoresLibros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAutoresLibros.Pages.Libros;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Libro Libro { get; set; } = new();

    public SelectList Autores { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro == null)
        {
            return NotFound();
        }

        Libro = libro;
        await CargarAutoresAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
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

        var libroDb = await _context.Libros.FindAsync(Libro.Id);
        if (libroDb == null)
        {
            return NotFound();
        }

        libroDb.Titulo = Libro.Titulo;
        libroDb.AnioPublicacion = Libro.AnioPublicacion;
        libroDb.Disponibilidad = Libro.Disponibilidad;
        libroDb.AutorId = Libro.AutorId;

        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Se actualizó el libro \"{libroDb.Titulo}\".";
        return RedirectToPage("./Index");
    }

    private async Task CargarAutoresAsync()
    {
        Autores = new SelectList(
            await _context.Autores.OrderBy(a => a.NombreCompleto).ToListAsync(),
            nameof(Autor.Id),
            nameof(Autor.NombreCompleto),
            Libro.AutorId);
    }
}
