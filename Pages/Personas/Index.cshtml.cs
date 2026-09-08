using _2026web3.Data;
using _2026web3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Pages.Personas
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Persona> Personas { get; set; } = new List<Persona>();

        [BindProperty(SupportsGet = true)]
        public string? Buscar { get; set; }

        public async Task OnGetAsync()
        {
            var consulta = _context.Personas
                .Include(p => p.Pais)
                .Include(p => p.Pasaporte)
                .Include(p => p.Materias)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(Buscar))
            {
                consulta = consulta.Where(p => p.Name.Contains(Buscar));
            }

            Personas = await consulta
                .OrderBy(p => p.Name)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
