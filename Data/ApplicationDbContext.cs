using _2026web3.Models;
using Microsoft.EntityFrameworkCore;

namespace _2026web3.Data;

public class ApplicationDbContext : DbContext
{
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Persona> Personas {  get; set; }
    public DbSet<Pasaporte> Pasaporte { get; set; }
    public DbSet<Pais> Pais { get; set; }
    public DbSet<Materia> Materia { get; set; } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Persona>()
            .HasOne(p => p.Pasaporte)
            .WithOne(pe => pe.Persona)
            .HasForeignKey<Pasaporte>(pa => pa.personaId);

        modelBuilder.Entity<Persona>()
            .HasOne(p => p.Pais)
            .WithMany(pe => pe.Personas)
            .HasForeignKey(pa => pa.paisId);

        modelBuilder.Entity<Persona>()
            .HasMany(p => p.Materias)
            .WithMany(m => m.Personas)
            .UsingEntity(j => j.ToTable("Inscripcion"));

        Seed(modelBuilder);
    }

    private static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pais>().HasData(
            new Pais { Id = 1, Name = "Guatemala" },
            new Pais { Id = 2, Name = "México" },
            new Pais { Id = 3, Name = "España" },
            new Pais { Id = 4, Name = "Estados Unidos" },
            new Pais { Id = 5, Name = "Argentina" });

        modelBuilder.Entity<Materia>().HasData(
            new Materia { Id = 1, Name = "Programación I", Creditos = 5 },
            new Materia { Id = 2, Name = "Bases de Datos", Creditos = 4 },
            new Materia { Id = 3, Name = "Desarrollo Web", Creditos = 5 },
            new Materia { Id = 4, Name = "Matemática Discreta", Creditos = 3 },
            new Materia { Id = 5, Name = "Redes de Computadoras", Creditos = 4 });

        modelBuilder.Entity<Persona>().HasData(
            new { Id = 1, Name = "Ana López", dob = new DateOnly(2000, 3, 15), paisId = 1 },
            new { Id = 2, Name = "Carlos Ramírez", dob = new DateOnly(1998, 7, 2), paisId = 2 },
            new { Id = 3, Name = "María Fernández", dob = new DateOnly(2001, 11, 20), paisId = 3 },
            new { Id = 4, Name = "Jorge Castillo", dob = new DateOnly(1999, 1, 8), paisId = 1 },
            new { Id = 5, Name = "Lucía Morales", dob = new DateOnly(2002, 6, 30), paisId = 5 });

        modelBuilder.Entity<Pasaporte>().HasData(
            new { Id = 1, Numero = "GT1234567", personaId = 1 },
            new { Id = 2, Numero = "MX7654321", personaId = 2 },
            new { Id = 3, Numero = "ES1122334", personaId = 3 });

        // Entidad implícita de la relación muchos a muchos Persona-Materia.
        modelBuilder.Entity("MateriaPersona").HasData(
            new { PersonasId = 1, MateriasId = 1 },
            new { PersonasId = 1, MateriasId = 2 },
            new { PersonasId = 1, MateriasId = 3 },
            new { PersonasId = 2, MateriasId = 2 },
            new { PersonasId = 2, MateriasId = 5 },
            new { PersonasId = 3, MateriasId = 1 },
            new { PersonasId = 3, MateriasId = 4 },
            new { PersonasId = 4, MateriasId = 3 },
            new { PersonasId = 5, MateriasId = 2 },
            new { PersonasId = 5, MateriasId = 3 },
            new { PersonasId = 5, MateriasId = 4 });
    }
}
