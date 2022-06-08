using Companies.Domain;
using Microsoft.EntityFrameworkCore;

namespace Companies.Infrastructure.Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
    }
}
