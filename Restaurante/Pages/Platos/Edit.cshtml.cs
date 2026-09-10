using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Platos
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plato Plato { get; set; } = new Plato();

        public SelectList ListaCategorias { get; set; }

        public IActionResult OnGet(int id)
        {
            Plato = _context.Platos.Find(id);
            if (Plato == null)
            {
                return NotFound();
            }

            ListaCategorias = new SelectList(_context.Categorias.ToList(), "Id", "Nombre");
            return Page();
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

            _context.Platos.Update(Plato);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
