using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Categorias
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; } = new Categoria();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("Categoria.Platos");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categorias.Add(Categoria);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
