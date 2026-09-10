using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Categoria> Categorias { get; set; }

        public void OnGet()
        {
            Categorias = _context.Categorias.ToList();
        }
    }
}
