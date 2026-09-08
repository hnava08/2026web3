using _2026web3.Data;
using _2026web3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Pages.Personas
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Persona Persona { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.Pais)
                .Include(p => p.Pasaporte)
                .Include(p => p.Materias)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (persona is null)
            {
                return NotFound();
            }

            Persona = persona;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var persona = await _context.Personas
                .Include(p => p.Materias)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (persona is null)
            {
                return RedirectToPage("./Index");
            }

            // Las inscripciones y el pasaporte se borran en cascada.
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = $"Se eliminó la persona \"{persona.Name}\".";
            return RedirectToPage("./Index");
        }
    }
}
