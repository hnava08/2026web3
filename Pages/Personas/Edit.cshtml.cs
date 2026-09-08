using System.ComponentModel.DataAnnotations;
using _2026web3.Data;
using _2026web3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Pages.Personas
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Persona Persona { get; set; } = default!;

        [BindProperty]
        [Display(Name = "Número de pasaporte")]
        public string? NumeroPasaporte { get; set; }

        [BindProperty]
        [Display(Name = "Materias")]
        public List<int> MateriasSeleccionadas { get; set; } = new();

        public SelectList Paises { get; set; } = default!;
        public List<Materia> TodasLasMaterias { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.Pasaporte)
                .Include(p => p.Materias)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (persona is null)
            {
                return NotFound();
            }

            Persona = persona;
            NumeroPasaporte = persona.Pasaporte?.Numero;
            MateriasSeleccionadas = persona.Materias.Select(m => m.Id).ToList();

            await CargarListasAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            // La navegación Pais no viaja en el formulario, solo su llave paisId.
            ModelState.Remove($"{nameof(Persona)}.{nameof(Persona.Pais)}");

            var personaEnBd = await _context.Personas
                .Include(p => p.Pasaporte)
                .Include(p => p.Materias)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (personaEnBd is null)
            {
                return NotFound();
            }

            if (!await _context.Pais.AnyAsync(p => p.Id == Persona.paisId))
            {
                ModelState.AddModelError($"{nameof(Persona)}.{nameof(Persona.paisId)}", "Debe seleccionar un país válido.");
            }

            if (!string.IsNullOrWhiteSpace(NumeroPasaporte)
                && await _context.Pasaporte.AnyAsync(p => p.Numero == NumeroPasaporte && p.personaId != id))
            {
                ModelState.AddModelError(nameof(NumeroPasaporte), "Ya existe otra persona con ese número de pasaporte.");
            }

            if (!ModelState.IsValid)
            {
                await CargarListasAsync();
                return Page();
            }

            personaEnBd.Name = Persona.Name;
            personaEnBd.dob = Persona.dob;
            personaEnBd.paisId = Persona.paisId;

            ActualizarPasaporte(personaEnBd);

            personaEnBd.Materias.Clear();
            if (MateriasSeleccionadas.Count > 0)
            {
                var materias = await _context.Materia
                    .Where(m => MateriasSeleccionadas.Contains(m.Id))
                    .ToListAsync();

                foreach (var materia in materias)
                {
                    personaEnBd.Materias.Add(materia);
                }
            }

            await _context.SaveChangesAsync();

            TempData["Mensaje"] = $"Se actualizó la persona \"{personaEnBd.Name}\".";
            return RedirectToPage("./Index");
        }

        private void ActualizarPasaporte(Persona personaEnBd)
        {
            var numero = NumeroPasaporte?.Trim();

            if (string.IsNullOrWhiteSpace(numero))
            {
                if (personaEnBd.Pasaporte is not null)
                {
                    _context.Pasaporte.Remove(personaEnBd.Pasaporte);
                }
                return;
            }

            if (personaEnBd.Pasaporte is null)
            {
                personaEnBd.Pasaporte = new Pasaporte { Numero = numero };
            }
            else
            {
                personaEnBd.Pasaporte.Numero = numero;
            }
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
