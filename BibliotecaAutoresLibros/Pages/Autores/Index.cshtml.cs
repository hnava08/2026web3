using BibliotecaAutoresLibros.Data;
using BibliotecaAutoresLibros.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAutoresLibros.Pages.Autores;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Autor> Autores { get; set; } = new List<Autor>();

    public async Task OnGetAsync()
    {
        Autores = await _context.Autores
            .Include(a => a.Libros)
            .OrderBy(a => a.NombreCompleto)
            .ToListAsync();
    }
}
