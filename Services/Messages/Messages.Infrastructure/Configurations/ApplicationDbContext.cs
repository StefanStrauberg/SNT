using Messages.Domain;
using Microsoft.EntityFrameworkCore;

namespace Messages.Infrastructure.Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Message> Messages { get; set; }
    }
}