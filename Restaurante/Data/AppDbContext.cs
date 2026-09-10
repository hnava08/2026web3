using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Plato> Platos { get; set; }
    }
}
