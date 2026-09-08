using System.ComponentModel.DataAnnotations;
using _2026web3.Data;
using _2026web3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Pages.Personas
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Persona Persona { get; set; } = new();

        [BindProperty]
        [Display(Name = "Número de pasaporte")]
        public string? NumeroPasaporte { get; set; }

        [BindProperty]
        [Display(Name = "Materias")]
        public List<int> MateriasSeleccionadas { get; set; } = new();

        public SelectList Paises { get; set; } = default!;
        public List<Materia> TodasLasMaterias { get; set; } = new();

        public async Task OnGetAsync()
        {
            await CargarListasAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // La navegación Pais no viaja en el formulario, solo su llave paisId.
            ModelState.Remove($"{nameof(Persona)}.{nameof(Persona.Pais)}");

            if (!await _context.Pais.AnyAsync(p => p.Id == Persona.paisId))
            {
                ModelState.AddModelError($"{nameof(Persona)}.{nameof(Persona.paisId)}", "Debe seleccionar un país válido.");
            }

            if (!string.IsNullOrWhiteSpace(NumeroPasaporte)
                && await _context.Pasaporte.AnyAsync(p => p.Numero == NumeroPasaporte))
            {
                ModelState.AddModelError(nameof(NumeroPasaporte), "Ya existe otra persona con ese número de pasaporte.");
            }

            if (!ModelState.IsValid)
            {
                await CargarListasAsync();
                return Page();
            }

            if (MateriasSeleccionadas.Count > 0)
            {
                Persona.Materias = await _context.Materia
                    .Where(m => MateriasSeleccionadas.Contains(m.Id))
                    .ToListAsync();
            }

            if (!string.IsNullOrWhiteSpace(NumeroPasaporte))
            {
                Persona.Pasaporte = new Pasaporte { Numero = NumeroPasaporte.Trim() };
            }

            _context.Personas.Add(Persona);
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = $"Se creó la persona \"{Persona.Name}\".";
            return RedirectToPage("./Index");
        }

        private async Task CargarListasAsync()
        {
            Paises = new SelectList(
                await _context.Pais.OrderBy(p => p.Name).ToListAsync(),
                nameof(Pais.Id),
                nameof(Pais.Name));

            TodasLasMaterias = await _context.Materia.OrderBy(m => m.Name).ToListAsync();
        }
    }
}
