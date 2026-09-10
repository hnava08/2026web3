using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Platos
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plato Plato { get; set; } = new Plato();

        public SelectList ListaCategorias { get; set; }

        public void OnGet()
        {
            ListaCategorias = new SelectList(_context.Categorias.ToList(), "Id", "Nombre");
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("Plato.Categoria");

            if (Plato.CategoriaId == 0)
            {
                ModelState.AddModelError("Plato.CategoriaId", "Debe seleccionar una categoria");
            }

            if (!ModelState.IsValid)
            {
                ListaCategorias = new SelectList(_context.Categorias.ToList(), "Id", "Nombre");
                return Page();
            }

            _context.Platos.Add(Plato);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
