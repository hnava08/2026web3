using BibliotecaAutoresLibros.Data;
using BibliotecaAutoresLibros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAutoresLibros.Pages.Libros;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Libro> Libros { get; set; } = new List<Libro>();

    // Carga de datos mediante OnGet (requisito del enunciado)
    public async Task OnGetAsync()
    {
        Libros = await _context.Libros
            .Include(l => l.Autor)
            .OrderBy(l => l.Titulo)
            .ToListAsync();
    }

    // Handler específico: asp-page-handler="Eliminar" -> OnPostEliminar
    public async Task<IActionResult> OnPostEliminarAsync(int id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro == null)
        {
            return NotFound();
        }

        _context.Libros.Remove(libro);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = $"Se eliminó el libro \"{libro.Titulo}\".";
        return RedirectToPage();
    }
}
