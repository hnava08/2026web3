using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Platos
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Plato> Platos { get; set; }

        public void OnGet()
        {
            Platos = _context.Platos.Include(p => p.Categoria).ToList();
        }

        public IActionResult OnPostEliminar(int id)
        {
            var plato = _context.Platos.Find(id);
            if (plato != null)
            {
                _context.Platos.Remove(plato);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
