using Microsoft.EntityFrameworkCore;

namespace _2026web3.Data;

public class ApplicationDbContext() : DbContext
{
     ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
}
